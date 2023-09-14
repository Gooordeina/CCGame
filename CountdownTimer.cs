using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CountdownTimer : MonoBehaviour
{
    //setting up variables
    public float currentTime = 0f;
    public float startingTime = 60f;

    public GameObject losepanel;

   [SerializeField] TextMeshProUGUI CountdownText;
    void Start()
    {   
        //at the start of the game, the current time equals to the starting time
        currentTime = startingTime;
    }

    void Update()
    {   
        //every second after the game starts, current time display decreeases by one
        currentTime -= 1 * Time.deltaTime;
        CountdownText.text = currentTime.ToString("0");

        //ensure the current time does not go smaller than zero
        if (currentTime <=0)
        {
            currentTime=0;
        }

        //lose function. if player didn't collect all the objects before the countdown finishes, lose panel pops out, game pauses, mouse cursor appears
           if (currentTime <= 0)
        {
            losepanel.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
