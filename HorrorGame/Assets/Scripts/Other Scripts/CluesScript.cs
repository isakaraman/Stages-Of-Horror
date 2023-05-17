using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CluesScript : MonoBehaviour
{
    [SerializeField] TMP_Text pressF;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Time.timeScale = 1;
            pressF.text = "";
            this.gameObject.SetActive(false);
        }
    }
}
