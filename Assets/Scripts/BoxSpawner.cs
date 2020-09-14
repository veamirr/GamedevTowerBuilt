using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject box_Prefab;

    public void SpawnBox()//spawn new box
    {
        GameObject box_Obj = Instantiate(box_Prefab);
        box_Obj.transform.position = new Vector3(transform.position.x, transform.position.y, 0);

    }
}
