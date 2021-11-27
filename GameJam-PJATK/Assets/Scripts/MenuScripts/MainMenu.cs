using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameData data;

    public GameObject Instructions;
    public GameObject Credits;
    public Dropdown Difficulty;

    void Start()
    {
        gameObject.SetActive(false);
        data.playerHP = 5;
    }

    public void DifficultySelected(Dropdown diff)
    {
        if(diff.value == 0)
        {
            data.playerHP = 5;
        }
        else if(diff.value == 1)
        {
            data.playerHP = 3;
        }
        else
        {
            data.playerHP = 1;
        }
    }

    public void PlayTheGame()
    {
        //SceneManager.LoadScene("...");
    }

    public void GoToInstructions()
    {
        gameObject.SetActive(false);
        Instructions.SetActive(true);
    }

    public void GoToCredits()
    {
        gameObject.SetActive(false);
        Credits.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
