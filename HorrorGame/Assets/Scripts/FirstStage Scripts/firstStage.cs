using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class firstStage : MonoBehaviour
{
    [SerializeField] private float delay = 0.1f;
    [SerializeField] private TMP_Text textComponent;
    private string textToDisplay;
    [SerializeField] PlayerMovement player;
    [SerializeField] GameObject arrows;
    [SerializeField] GameObject wall;
    [SerializeField] AudioSource letterSound;
    [SerializeField] AudioSource bzztSound;

    bool skip;
    public bool skip2;
    [SerializeField] TMP_Text skipText;

    private Coroutine textCoroutine;
    private Coroutine fsCoroutine;

    private void Start()
    {
        StartTyping();
    }
    private void Update()
    {
        if (!skip)
        {
            skipText.text = "Press F for skip";
            if (Input.GetKeyDown(KeyCode.F))
            {
                StopCoroutine(textCoroutine);
                bzztSound.Play();
                arrows.gameObject.SetActive(true);
                textComponent.text = "";
                player.gameStart = true;
                skipText.text = "";
                skip = true;
            }
        }

        if (skip2)
        {
            skipText.text = "Press F for skip";
            if (Input.GetKeyDown(KeyCode.F))
            {
                StopCoroutine(fsCoroutine);
                textComponent.text = "";
                player.gameStart = true;
                skipText.text = "";
                skip2 = false;
                wall.gameObject.SetActive(false);
            }
        }
    }
    void StartTyping()
    {
        textToDisplay = "Welcome.";
        textCoroutine=StartCoroutine(ShowText());
    }
    public void firstStageText()
    {
        textToDisplay = "Here is the first stage.";
        fsCoroutine=StartCoroutine(FirstStageText());
    }
    IEnumerator ShowText()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i <= textToDisplay.Length; i++)
        {
            letterSound.Play();
            textComponent.text = textToDisplay.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(1f);
        textToDisplay = "Follow the path and pass the first stage";
        for (int i = 0; i <= textToDisplay.Length; i++)
        {
            letterSound.Play();
            textComponent.text = textToDisplay.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(1f);
        bzztSound.Play();
        arrows.gameObject.SetActive(true);
        skip = true;
        yield return new WaitForSeconds(1f);
        skipText.text = "";
        textComponent.text ="";
        player.gameStart = true;

    }
    IEnumerator FirstStageText()
    {
        for (int i = 0; i <= textToDisplay.Length; i++)
        {
            letterSound.Play();
            textComponent.text = textToDisplay.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(1f);

        textToDisplay = " As soon as you touch the green line, the first phase will begin.";
        for (int i = 0; i <= textToDisplay.Length; i++)
        {
            letterSound.Play();
            textComponent.text = textToDisplay.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(1f);
        textToDisplay = "Try to figure out what to do before you cross the line.";
        for (int i = 0; i <= textToDisplay.Length; i++)
        {
            letterSound.Play();
            textComponent.text = textToDisplay.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }

        skip2 = false;
        yield return new WaitForSeconds(1f);
        wall.gameObject.SetActive(false);
        skipText.text = "";
        textComponent.text = "";
        player.gameStart = true;
    }
}