using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterHead : MonoBehaviour
{
    [SerializeField] Transform playerPos;

    [SerializeField] Camera cameraObj;

    [SerializeField] GameObject body;

    [SerializeField] float monsterSpeed;
    float timer = 1;

    [SerializeField] bool startingToFollow = true;

    public bool levelOneStartCheck;
    bool state1, state2;

    void Update()
    {
        if (levelOneStartCheck)
        {
            if (IsWithinFieldOfView())
            {
                startingToFollow = true;                
            }
            else
            {
                timer -= Time.deltaTime;
                if (timer <= 0 && !state1)
                {
                    transform.LookAt(playerPos);
                    gameObject.transform.position += new Vector3(0, 0.3f, 0);
                    timer = 1;
                }
                if (gameObject.transform.position.y >= 2.8f)
                {

                    state1 = true;
                    if (!state2)
                    {

                        gameObject.transform.position = new Vector3(14.27f, 3.9f, -0.73f);
                        body.gameObject.SetActive(true);
                        transform.LookAt(playerPos);
                        state2 = true;
                    }

                    startingToFollow = false;
                    if (!startingToFollow)
                    {
                        transform.LookAt(playerPos);
                        Vector3 playerPosWithoutY = new Vector3(playerPos.transform.position.x, transform.position.y, playerPos.transform.position.z);
                        Vector3 direction = (playerPosWithoutY - transform.position).normalized;
                        transform.position += direction * monsterSpeed * Time.deltaTime;
                    }

                }
            }
        }
    }
    private bool IsWithinFieldOfView()
    {
        Vector3 screenPoint = cameraObj.WorldToViewportPoint(transform.position);
        return screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
    }

}
