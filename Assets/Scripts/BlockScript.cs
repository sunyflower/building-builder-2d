using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BlockScript : MonoBehaviour
{
    //strefa poruszania klocka na boki
    private float max_X = 1.6f;

    private bool canMove;

    //i szybkosc
    private float move_Speed = 2f;

    private Rigidbody2D myBody;

    private bool gameOver;
    private bool ignoreCollision;


    //przypisujemy rigidbody do zmiennej i wylaczamy mu grawitacje zeby nie spadal
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myBody.gravityScale = 0f;
    }


    //podpinamy do game controllera ten block
    void Start()
    {
        canMove = true;

        GameplayController.instance.currentBlock = this;
    }



    void Update()

     //poruszanie klocka
    {
        MoveBlock();
    }

    
    void MoveBlock()
    {
        if (canMove)
        {

            Vector3 temp = transform.position;

            temp.x = Mathf.Sin(Time.time * move_Speed) * max_X;

            transform.position = temp;
        }
    }



    //upuszczenie klocka, ustawienie grawitacji randomowo
    public void DropBlock()
    {
        canMove = false;
        myBody.gravityScale = Random.Range(2, 4);
    }


    //
    void Landed()
    {
        //sprawdzanie czy gra sie skonczyla
        if (gameOver)
            return;

        //zignorowac kolizje jakakolwiek
        ignoreCollision = true;

        Score.Instance.AddScore();
        GameplayController.instance.SpawnNewBlock();
        GameplayController.instance.MoveCamera();
    }


    //restart gry
    void RestartGame()
    {
        GameplayController.instance.RestartGame();
    }


    //sprawdzenie czy jest kolizja z platforma lub blockiem
    void OnCollisionEnter2D(Collision2D target)
    {
        if (ignoreCollision)
            return;

        if (target.gameObject.tag == "platform" || target.gameObject.tag == "block")
        {
            Landed();
            ignoreCollision = true;
        }
   
    }


    //game over i restart gry
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "GameOver")
        {
            gameOver = true;

            Invoke("RestartGame", 2f);
        }
    }
}


