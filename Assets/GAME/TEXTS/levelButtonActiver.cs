using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelButtonActiver : MonoBehaviour {

    int activelevel;
    public Button[] buttons;

    void Start () {
        activelevel = PlayerPrefs.GetInt ("savedlevel" , 1);

        for (int i = 0; i < buttons.Length; i++) {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < (activelevel - 1); i++) {
            buttons[i].interactable = true;
        }

    }

    // Update is called once per frame
    void Update () {

    }
}