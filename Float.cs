using System.Collections;
using UnityEngine;


public class Float : MonoBehaviour
{
    //creating assets and variables
    int i = 1;
    public float offsetamount;
    public GameObject pausescrpt;
    public float amount;
    public float x = 0;
    void Update()
    {
    //getting the gamepause variable from the PauseMenu Script
        PauseMenu pm = pausescrpt.GetComponent<PauseMenu>();
        x = Time.time;      
    //calculate offest using time and sine wave
        offsetamount = Mathf.Sin(x) * amount;
    //apply the offset to each cube if the game is not paused
        if(pm.GameIsPaused == false)
        {
            foreach(GameObject cube in GameObject.FindGameObjectsWithTag("PickUpObject"))
            {
                cube.transform.position += new Vector3(+0, +offsetamount, +0);
            }   
        }
       
    }
}
