using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class levelOneButton : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text pressE;

    [SerializeField] GameObject otherButton;
    [SerializeField] GameObject theDoorClosed;
    [SerializeField] GameObject theDoorOpened;

    [SerializeField] AudioSource doorOpenSFX;

    public void whenButtonHit()
    {
        otherButton.gameObject.SetActive(true);
        gameObject.SetActive(false);
        pressE.text = "";

        theDoorClosed.gameObject.SetActive(false);
        theDoorOpened.gameObject.SetActive(true);

        doorOpenSFX.Play();
    }
}
