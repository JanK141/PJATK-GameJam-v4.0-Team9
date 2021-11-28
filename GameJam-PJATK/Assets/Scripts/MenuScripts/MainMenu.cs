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

    public GameEventSystem sys;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void DifficultySelected(Dropdown diff)
    {
        if(diff.value == 0)
        {
            PlayerPrefs.SetInt("HP", 5);
            //GameEventSystem.Instance.SetHP(5);
        }
        else if(diff.value == 1)
        {
            PlayerPrefs.SetInt("HP", 3);
            //GameEventSystem.Instance.SetHP(3);
        }
        else
        {
            PlayerPrefs.SetInt("HP", 1);
            //GameEventSystem.Instance.SetHP(1);
        }
    }


    public void PlayTheGame()
    {
        //SceneManager.LoadScene("...");
        GameEventSystem.Instance.NewGame(data);
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
