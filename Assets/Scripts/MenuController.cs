using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;

    public void ChangePanel() {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }
}
