using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameController : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMvmnt;
    [SerializeField] PlayerCam playerCm;

    [SerializeField] TMPro.TMP_Text gameoverText;
    [SerializeField] Button restartButton;

    
    public void gameOver()
    {
        playerMvmnt.gameOverCheck = true;
        playerCm.gameOverCheck = true;

        gameoverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void restartButtonWork()
    {
        SceneManager.LoadScene(1);
    }
    public void quitgame()
    {
        Application.Quit();
    }
}
