using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour {
    public static GameObject[] monks;
    public static GameObject[] lizards;
    private static GameObject[] blood;
    public static List<GameObject> bloodLay;
    public static List<GameObject> bloodRun;
    public static List<GameObject> bloodCarry;
    private int lizardBloodCount = 0;
    private int monkBloodCount = 0;

    [SerializeField]
    private GameObject lizard;
    [SerializeField]
    private Transform lizardHouse;
    [SerializeField]
    private GameObject monk;
    [SerializeField]
    private Transform monkHouse;
    [SerializeField]
    private TMP_Text lizardBloodText;
    [SerializeField]
    private TMP_Text monkBloodText;
    void Start() {
        bloodLay = new List<GameObject>();
        bloodCarry = new List<GameObject>();
        bloodRun = new List<GameObject>();
    }
    void Update() {
        lizardBloodText.text = "Lizard Blood: " + GetLizardBloodCount().ToString();
        monkBloodText.text = "Monk Blood: " + GetMonkBloodCount().ToString();
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
    public List<GameObject> GetLayBlood() {
        return bloodLay;
    }
    public List<GameObject> GetRunBlood() {
        return bloodRun;
    }
    public List<GameObject> GetCarryBlood() {
        return bloodCarry;
    }
    public GameObject[] GetMonks() {
        return monks;
    }
    public GameObject[] GetLizards() {
        return lizards;
    }
    public void LizardSpawn() {
        if (lizardBloodCount > 0) {
            Instantiate(lizard, lizardHouse.position, lizardHouse.rotation);
            RemoveLizardBloodCount(1);
        }
    }
    public void MonkSpawn() {
        if (monkBloodCount > 0) {
            Instantiate(monk, lizardHouse.position, lizardHouse.rotation);
            RemoveMonkBloodCount(1);
        }
    }
    public void AddLizardBloodCount(int _lizardBloodCount) {
        lizardBloodCount += _lizardBloodCount;
    }
    public void RemoveLizardBloodCount(int _lizardBloodCount) {
        lizardBloodCount -= _lizardBloodCount;
    }
    public int GetLizardBloodCount() {
        return lizardBloodCount;
    }
    public void AddMonkBloodCount(int _monkBloodCount) {
        monkBloodCount += _monkBloodCount;
    }
    public void RemoveMonkBloodCount(int _monkBloodCount) {
        monkBloodCount -= _monkBloodCount;
    }
    public int GetMonkBloodCount() {
        return monkBloodCount;
    }
}
