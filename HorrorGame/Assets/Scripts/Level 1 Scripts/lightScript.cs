using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightScript : MonoBehaviour
{
    [SerializeField] GameObject lightOn, lightOff;

    AudioSource audiosource;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="GameOver")
        {
            audiosource.Play();
            lightOn.gameObject.SetActive(true);
            lightOff.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="GameOver")
        {
            lightOn.gameObject.SetActive(false);
            lightOff.gameObject.SetActive(true);
        }
    }
}
