using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class levelOneExitButton : MonoBehaviour
{
    [SerializeField] TMP_Text pressE;
    [SerializeField] TMP_Text win;

    [SerializeField] GameObject otherButton;
    [SerializeField] GameObject theDoorClosed;
    [SerializeField] GameObject theDoorOpened;

    [SerializeField] AudioSource doorCloseSFX;

    [SerializeField] GameObject monster;

    [SerializeField] Button restart;
    [SerializeField] Button quit;

    [SerializeField] PlayerMovement player;
    public void whenButtonHit()
    {
        otherButton.gameObject.SetActive(true);
        gameObject.SetActive(false);
        pressE.text = "";

        theDoorClosed.gameObject.SetActive(true);
        theDoorOpened.gameObject.SetActive(false);

        doorCloseSFX.Play();

        monster.gameObject.SetActive(false);

        restart.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);

        player.gameStart = false;

        win.gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
