using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        //rotate function. it rotates the object by (angles of 15, 30, 45 degrees), taking into account the frame time using "Time.deltaTime".
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
