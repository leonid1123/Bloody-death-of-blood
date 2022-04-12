using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selector : MonoBehaviour {

    [SerializeField]
    GameObject sel;

    private void Start() {
        sel.SetActive(false);
    }
    private void OnMouseDown() {
        sel.SetActive(true);
    }

}
