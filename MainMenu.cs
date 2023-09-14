using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    // levelselection function. click the buton to bring the player to the level selectiion menu from the main menu
   public void PlayGame ()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
   //quit game function. quit the game after clicking
    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
