using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMcontinue : MonoBehaviour
{
   private void Awake()
   {
    // Find the game object with the "BGM" tag in the scene.
    GameObject[] musicObj = GameObject.FindGameObjectsWithTag("BGM");
    //This is to check if there is more than one game object with the "BGM" tag, and if there is more than bgm, destroy this bgm to prevent duplicates.
    if(musicObj.Length > 1)
    {
        Destroy(this.gameObject);
    }
    //Keep this the object that contains the tag when loading new scenes so the bgm keeps playing.
    DontDestroyOnLoad(this.gameObject);
   }
}
