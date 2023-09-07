using System.Collections;
using UnityEngine;


public class Float : MonoBehaviour
{
    int i = 1;
    public float offsetamount;
    public float amount;
    public float x = 0;
    void Update()
    {
        x = Time.time;  

        offsetamount = Mathf.Sin(x) * amount;
        foreach(GameObject cube in GameObject.FindGameObjectsWithTag("PickUpObject"))
        {

            cube.transform.position += new Vector3(+0, +offsetamount, +0);
        }
           


    }

    
    
}
