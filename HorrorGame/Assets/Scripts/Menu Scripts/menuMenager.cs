using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class menuMenager : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
