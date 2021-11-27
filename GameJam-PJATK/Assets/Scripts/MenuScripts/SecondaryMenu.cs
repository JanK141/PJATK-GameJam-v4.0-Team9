using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryMenu : MonoBehaviour
{
    public GameObject MainMenu;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void JustGoBack()
    {
        gameObject.SetActive(false);
        MainMenu.SetActive(true);
    }
}
