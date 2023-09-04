using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CountdownTimer : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 60f;

    public GameObject losepanel;

   [SerializeField] TextMeshProUGUI CountdownText;
    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        CountdownText.text = currentTime.ToString("0");

        if (currentTime <=0)
        {
            currentTime=0;
        }

           if (currentTime <= 0)
        {
            losepanel.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
