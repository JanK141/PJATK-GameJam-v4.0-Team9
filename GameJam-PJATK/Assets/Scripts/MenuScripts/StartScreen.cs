using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public GameObject MainMenu;
    public Text PressKeyTxt;

    private void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            GoToMainMenu();
        }
    }

    public void GoToMainMenu()
    {
        gameObject.SetActive(false);
        MainMenu.SetActive(true);
    }
}
