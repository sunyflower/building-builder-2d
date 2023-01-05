using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
      public static GameplayController instance;

      public BlockSpawner block_Spawner;
     
     [HideInInspector]
      public BlockScript currentBlock;

      void Awake() {
        if(instance == null)
           instance = this;

      }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
