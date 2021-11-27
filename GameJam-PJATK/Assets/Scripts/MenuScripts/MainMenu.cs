using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Instructions;
    public GameObject Credits;
    public Dropdown Difficulty;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DifficultySelected(Dropdown diff)
    {
        int HP; 

        if(diff.value == 0)
        {
            HP = 5;
        }
        else if(diff.value == 1)
        {
            HP = 3;
        }
        else
        {
            HP = 1;
        }
        
        //tutaj trzeba ustawic HP gracza na te wartosc
        //GameData.PlayerHP = HP;
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
