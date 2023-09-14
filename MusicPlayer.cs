using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    //creating variables and assets
    public AudioSource Backgroundmusic; 
    public GameObject ObjectMusic;

    //setting the initial volume at maximum which is 1.
    private float musicVolume = 1f;
    // Start is called before the first frame update
    void Start()
    {
    //Find the game object with the tag "BGM" in the scene 
        ObjectMusic = GameObject.FindWithTag("BGM");
    //Give the access of the Audio Source Component to Backgroundmusic
        Backgroundmusic = ObjectMusic.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    //Enable me to control and update the background music's volume dynamically with the slide bar, ensuring that it aligns with user preferences and changes made during gameplay.
        Backgroundmusic.volume = musicVolume;
    }

    //creating the updateVolume funcion so can be used in Unity
    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }

}
