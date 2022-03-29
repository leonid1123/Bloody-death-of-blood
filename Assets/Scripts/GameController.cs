using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameObject[] monks;
    void Start() {

    }
    void Update() {
        monks = GameObject.FindGameObjectsWithTag("Monk");
    }
    public GameObject[] GetMonks() {
        return monks;
    }
}
