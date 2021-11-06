using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    void Update()
    {
        Vector3 pos = GameObject.Find("MainPlayer").transform.position;
        pos.z = 1;
        transform.position = pos;
        
        
    }


}
