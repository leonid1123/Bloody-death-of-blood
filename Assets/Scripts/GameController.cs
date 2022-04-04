using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameObject[] monks;
    public static GameObject[] lizards;
    private static GameObject[] blood;
    public static List<GameObject> bloodLay;
    public static List<GameObject> bloodRun;
    public static List<GameObject> bloodCarry;

    [SerializeField]
    private GameObject lizard;
    [SerializeField]
    private Transform lizardHouse;
    [SerializeField]
    private GameObject monk;
    [SerializeField]
    private Transform monkHouse;
    void Start() {
        bloodLay = new List<GameObject>();
        bloodCarry = new List<GameObject>();
        bloodRun = new List<GameObject>();
    }
    void Update() {
        bloodLay.Clear();
        bloodCarry.Clear();
        bloodRun.Clear();
        monks = GameObject.FindGameObjectsWithTag("Monk");
        lizards = GameObject.FindGameObjectsWithTag("Lizard");
        blood = GameObject.FindGameObjectsWithTag("Blood");
        foreach (GameObject bld in blood) {
            string state = bld.GetComponent<BloodBottleController>().GetBottleState();
            if (state == "lay") {
                bloodLay.Add(bld);
            } else if (state == "run") {
                bloodRun.Add(bld);
            } else if (state == "carry") {
                bloodCarry.Add(bld);
            }
        }
    }
    public List<GameObject> GetLayBlood(){
        return bloodLay;
    }
    public List<GameObject> GetRunBlood(){
        return bloodRun;
    }
    public List<GameObject> GetCarryBlood(){
        return bloodCarry;
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
