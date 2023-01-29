using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {

  //spawnowanie blocka

  public GameObject block_Prefab;

  public void SpawnBlock () {
     GameObject block_Obj = Instantiate(block_Prefab);

     Vector3 temp = transform.position;
     temp.z = 0f;
     
     block_Obj.transform.position = temp;

  }

}
