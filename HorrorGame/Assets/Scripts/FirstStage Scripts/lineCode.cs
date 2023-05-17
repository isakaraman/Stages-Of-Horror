using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class lineCode : MonoBehaviour
{
    [SerializeField] monsterHead monstrHead;

    [SerializeField] GameObject wall;

    [SerializeField] GameObject greenLine,redLine;

    [SerializeField] BoxCollider boxcollider;
    [SerializeField] MeshRenderer mesh;

    [SerializeField] AudioSource audioS;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            wall.gameObject.SetActive(true);
            StartCoroutine(starts());
            monstrHead.levelOneStartCheck=true;
            mesh.enabled = false;
            boxcollider.enabled = false;

            greenLine.gameObject.SetActive(false);
            redLine.gameObject.SetActive(true);

            audioS.Play();
        }
    }

    IEnumerator starts()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
