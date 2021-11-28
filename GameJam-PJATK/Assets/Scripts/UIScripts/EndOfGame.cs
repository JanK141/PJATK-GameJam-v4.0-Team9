using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGame : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void GoToMainMenu()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
