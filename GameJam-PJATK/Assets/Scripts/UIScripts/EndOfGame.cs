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
        var audioPlayer = FindObjectOfType<AudioPlayer>().gameObject;
        Destroy(audioPlayer);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoToNextLevel()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("FajnyLevel");
    }
}
