using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerHits : MonoBehaviour
{
    public float raycastDistance = 2f; 
    [SerializeField] TMPro.TMP_Text pressE;
    [SerializeField] TMPro.TMP_Text pressF;

    [SerializeField] Image clues;
    [SerializeField] Sprite[] clueTextures;
    void Update()
    {
        
        Camera cam = Camera.main;
        Vector3 mousePos = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        
        Ray ray = cam.ScreenPointToRay(mousePos);
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y + 1f,transform.position.z);
        RaycastHit hit;
        if (Physics.Raycast(newPos, ray.direction, out hit, raycastDistance))
        {
            if (hit.collider.gameObject.name== "PassButton")
            {
                pressE.text = "Press E";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<levelOneButton>().whenButtonHit();
                }
               
            }
            else if (hit.collider.gameObject.name =="ExitButton")
            {
                pressE.text = "Press E";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<levelOneExitButton>().whenButtonHit();
                }

            }
            else if (hit.collider.gameObject.name== "levelonehint")
            {
                pressE.text = "Press E";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    clues.gameObject.GetComponent<Image>().sprite = clueTextures[0];
                    clues.gameObject.SetActive(true);
                    Time.timeScale = 0;
                    pressF.text = "Press F for exit";
                }
            }
            else
            {
                pressE.text = "";
            }
        }
        else
        {
            pressE.text = "";
        }

        Debug.DrawRay(newPos, ray.direction * raycastDistance, Color.red);
    }
}
