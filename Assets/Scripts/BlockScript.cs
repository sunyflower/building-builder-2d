using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BlockScript : MonoBehaviour {

   private float min_X = -1.6f, max_X = 1.6f;

   private bool canMove;
   private float move_Speed = 2f;

   private Rigidbody2D myBody;

   private bool gameOver;
   private bool ignoreCollision;
   private bool ignoreTrigger;


   void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        myBody.gravityScale = 0f;
   }



    // Start is called before the first frame update
    void Start() {
        canMove = true;

        if(Random.Range(0, 2) > 0) {
            move_Speed *= -1f;
        }
    }



    // Update is called once per frame
    void Update() {
        MoveBlock();
    }
    
    void MoveBlock() {
        if(canMove) {

            Vector3 temp = transform.position;

            temp.x += move_Speed * Time.deltaTime;

            if(temp.x > max_X) {
                move_Speed *= -1f;


            } else if (temp.x < min_X) {
                move_Speed *= -1f;
            }
            
            transform.position = temp;
        }  
    }
}
