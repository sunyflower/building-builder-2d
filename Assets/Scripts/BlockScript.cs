using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BlockScript : MonoBehaviour
{

    private float max_X = 1.6f;

    private bool canMove;
    private float move_Speed = 2f;

    private Rigidbody2D myBody;

    private bool gameOver;
    private bool ignoreCollision;


    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myBody.gravityScale = 0f;
    }



    // Start is called before the first frame update
    void Start()
    {
        canMove = true;

        GameplayController.instance.currentBlock = this;
    }



    // Update is called once per frame
    void Update()
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


    public void DropBlock()
    {
        canMove = false;
        myBody.gravityScale = Random.Range(2, 4);
    }


    void Landed()
    {
        if (gameOver)
            return;

        ignoreCollision = true;

        Score.Instance.AddScore();
        GameplayController.instance.SpawnNewBlock();
        GameplayController.instance.MoveCamera();
    }


    void RestartGame()
    {
        GameplayController.instance.RestartGame();
    }


    void OnCollisionEnter2D(Collision2D target)
    {
        if (ignoreCollision)
            return;

        if (target.gameObject.tag == "platform")
        {
            Landed();
            ignoreCollision = true;
        }
        else
        if (target.gameObject.tag == "block")
        {
            Landed();
            ignoreCollision = true;
        }
    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "GameOver")
        {
            CancelInvoke("Landed");
            gameOver = true;

            Invoke("RestartGame", 2f);
        }
    }
}


