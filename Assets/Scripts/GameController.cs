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
    private Transform[] lizardHouse;
    [SerializeField]
    private GameObject monk;
    [SerializeField]
    private Transform monkHouse;
    [SerializeField]
    private TMP_Text lizardBloodText;
    
    [SerializeField]
    private GameObject bloodBottle;
    [SerializeField]
    private GameObject lizardCarrier;
    [SerializeField]
    private GameObject monkCarrier;
    [SerializeField]
    private TMP_Text monkBloodText;
    void Start() {
        bloodLay = new List<GameObject>();
        bloodCarry = new List<GameObject>();
        bloodRun = new List<GameObject>();
    }


    void FixedUpdate() {
        
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
        //спавнить несуна тут!!!
        foreach(GameObject bottle in bloodLay) {
            //спавнить несуна
            //давать несуну бутылку
            //менять статус бутылки
            GameObject newCarrier1 = Instantiate(monkCarrier, monkHouse.position, monkHouse.rotation);
            newCarrier1.GetComponent<MonkCarrierController>().setBottleToRun(bottle);
            bottle.GetComponent<BloodBottleController>().SetBottleState("run");
            
            GameObject newCarrier2 = Instantiate(lizardCarrier, lizardHouse[0].position, lizardHouse[0].rotation);
            newCarrier2.GetComponent<LizardCarrierController>().setBottleToRun(bottle);
            bottle.GetComponent<BloodBottleController>().SetBottleState("run");
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
            if(Random.value>0.5) {
                Instantiate(lizard, lizardHouse[0].position, lizardHouse[0].rotation);
            } else {
                Instantiate(lizard, lizardHouse[1].position, lizardHouse[1].rotation);
            }
            RemoveLizardBloodCount(1);
        }
    }
    public void MonkSpawn() {
        if (monkBloodCount > 0) {
            Instantiate(monk, monkHouse.position, monkHouse.rotation);
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
