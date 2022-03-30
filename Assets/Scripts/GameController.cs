using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameObject[] monks;
    public static GameObject[] lizards;

    [SerializeField]
    private GameObject lizard;
    [SerializeField]
    private Transform lizardHouse;
    [SerializeField]
    private GameObject monk;
    [SerializeField]
    private Transform monkHouse;
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
    public void LizardSpawn() {
        Instantiate(lizard, lizardHouse.position, lizardHouse.rotation);
    }
    public void MonkSpawn() {
        Instantiate(monk, lizardHouse.position, lizardHouse.rotation);
    }
}
