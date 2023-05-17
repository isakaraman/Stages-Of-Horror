using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public gameController gameContrllr;
    [SerializeField] GameObject deatheffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="GameOver")
        {
            gameContrllr.gameOver();
            deatheffect.gameObject.SetActive(true);
        }
    }
}
