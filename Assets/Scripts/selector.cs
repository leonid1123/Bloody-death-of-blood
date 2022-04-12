using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selector : MonoBehaviour {
    GameObject[] sel;
    private void Awake() {
        sel = GameObject.FindGameObjectsWithTag("LizardSpawnPointSelector");
        foreach (GameObject s in sel) {
            s.SetActive(false);
        }
        Debug.Log(sel.Length);
    }
    private void OnMouseDown() {
        foreach (GameObject s in sel) {
            s.SetActive(false);
        }
        transform.GetChild(0).gameObject.SetActive(true);
    }
// сделать нормальный механизм выбора домика
// ВЕРУТЬСЯ к ОСТАЛЬНЫМ проблеМам!!!!
}
