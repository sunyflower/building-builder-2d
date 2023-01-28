using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //graj (aktywowanie następnej sceny)
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);

    }

    //wyjście z gry
    public void QuitGame ()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
