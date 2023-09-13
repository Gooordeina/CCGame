using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource Backgroundmusic; 
    public GameObject ObjectMusic;

    private float musicVolume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        ObjectMusic = GameObject.FindWithTag("BGM");
        Backgroundmusic = ObjectMusic.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Backgroundmusic.volume = musicVolume;
    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }

}
