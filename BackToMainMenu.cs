using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToMainMenu : MonoBehaviour
{
 public void LoadMenu()
    {
    //Back to Main Menu Function.
        SceneManager.LoadScene("Menu");
    }
}
