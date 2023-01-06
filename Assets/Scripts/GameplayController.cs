using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
      public static GameplayController instance;

      public BlockSpawner block_Spawner;
     
     [HideInInspector]
      public BlockScript currentBlock;

      public CameraFollow cameraScript;
      private int moveCount;

      void Awake() {
        if(instance == null)
           instance = this;

      }



    // Start is called before the first frame update
    void Start()
    {
       block_Spawner.SpawnBlock(); 
    }

    // Update is called once per frame
    void Update()
    {
     DetectInput();     
    }

    void DetectInput() {
      if (Input.GetMouseButtonDown(0)) {
        currentBlock.DropBlock();
      }
    }

    public void SpawnNewBlock() {
      Invoke("NewBlock", 2f);
    }

    void NewBlock() {
      block_Spawner.SpawnBlock();
    }

}
