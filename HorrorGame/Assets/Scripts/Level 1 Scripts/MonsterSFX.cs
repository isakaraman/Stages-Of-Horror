using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSFX : MonoBehaviour
{
    public AudioSource audiosource;
    public Camera playerCamera;                // Reference to the player's transform
    public float rotationSpeed = 5f;        // Speed at which the player rotates towards the object

    private bool isTurning = false;
    private Quaternion targetRotation;
    [SerializeField] monsterHead monsterhead;

    [SerializeField] Transform monsterheadObj;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audiosource.Play();
            isTurning = true;
            monsterhead.enabled=false;
        }
    }

    private void Update()
    {
        if (isTurning)
        {
            // Calculate the target direction from the object to the camera
            Vector3 targetDirection = monsterheadObj.position -playerCamera.transform.position;
           

            // Calculate the rotation towards the target direction using Quaternion.LookRotation
            targetRotation = Quaternion.LookRotation(targetDirection);

            // Smoothly rotate the camera towards the target rotation using Slerp
            playerCamera.transform.rotation = Quaternion.Slerp(playerCamera.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
