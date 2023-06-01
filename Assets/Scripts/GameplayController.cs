using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{     //zeby wywolac
      public static GameplayController instance;

      public BlockSpawner block_Spawner;

     //schowanie publiczenj zmiennej
     [HideInInspector]
      public BlockScript currentBlock;

      public CameraFollow cameraScript;
      private int moveCount;



     //podczas tworzenia obiektu
    void Awake()
     {
       if(instance == null)
          instance = this;
     }



    //spawn blocka
    void Start()
    {
       block_Spawner.SpawnBlock(); 
    }



    //sprawdzanie czy space jest klikniete
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentBlock.DropBlock();
        }
    }

  

    //spawnowanie blocka po 1 sek
    public void SpawnNewBlock()
    {
      Invoke("NewBlock", 1f);
    }



    //spawn new block 
    void NewBlock()
    {
      block_Spawner.SpawnBlock();
    }



    //śledząca kamera 
    public void MoveCamera() {

      moveCount++;

      if(moveCount == 3)
        {
         moveCount = 0;

         cameraScript.targetPos.y += 2f;
        }
    }



    //Restart gry, zaladowanie sceny
    public void RestartGame()
    {
      SceneManager.LoadScene(
      SceneManager.GetActiveScene().name);
    }

}
