using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
      public static GameplayController instance;

      public BlockSpawner block_Spawner;
     
     [HideInInspector]
      public BlockScript currentBlock;

      public CameraFollow cameraScript;
      private int moveCount;

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


    //
    void Update()
    {
     DetectInput();     
    }

    //przycisk dropu blocka
    void DetectInput() {
        if(Input.GetKeyDown(KeyCode.Space))
      {
        currentBlock.DropBlock();
      }
    }


    //spawnowanie blocka po 1 sek
    public void SpawnNewBlock()
    {
      Invoke("NewBlock", 1f);
    }

    //nowy block ?
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
