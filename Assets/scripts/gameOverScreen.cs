using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class gameOverScreen : MonoBehaviour
{

    public void NewGame()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadMenu()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

}
