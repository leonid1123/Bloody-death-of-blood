using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameObject[] monks;
    public static GameObject[] lizards;
    void Start() {

    }
    void Update() {
        monks = GameObject.FindGameObjectsWithTag("Monk");
        lizards = GameObject.FindGameObjectsWithTag("Lizard");
    }
    public GameObject[] GetMonks() {
        return monks;
    }
    
    public GameObject[] GetLizards() {
        return lizards;
    }
}
