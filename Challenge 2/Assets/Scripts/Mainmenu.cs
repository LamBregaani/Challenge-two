using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void OnePlayer()
    {
        SceneManager.LoadScene("One player");
    }

    public void TwoPlayer()
    {
        SceneManager.LoadScene("Two player");
    }


    public void QuitGame ()

    {
        Application.Quit();
    }

}

