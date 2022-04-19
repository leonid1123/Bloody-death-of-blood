using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//находит все бутылки с кровью и следит за статусами бутылок
//печатает сколько крови у каждой стороны
//отвечает за спавн всех несунов
//отвечает за спавн лизардов, если они активный игрок
//должен отвечать за спавн монахов, если он активный игрок
public class GameController : MonoBehaviour {

    public static GameObject[] monks;
    // список всех монахов, для нахождения ближайшего
    // этот список получают лизарды
    public static GameObject[] lizards;
    //список всех лизардов для нахождения ближайшего
    //этот список получают монахи
    private static GameObject[] blood;
    //список всех банок крови, для спавна несунов
    //этот список получают ВСЕ несуны
    private static GameObject[] lizardSpawn;
    // список всех домиков лизардов для выбора места спавна лизардов и несунов
    public static List<GameObject> bloodLay;
    //список банок крови со статусом "лежит lay" для создания нового несуна
    public static List<GameObject> bloodRun;
    //список банок крови со статусом "за ней бегут run" для того чтобы за ней не бежали
    public static List<GameObject> bloodCarry;
    //список банок крови со статусом "её несут в домик carry" для того чтобы она перемещалась вместе с несуном
    private int lizardBloodCount = 0;//количество крови у лизардов
    private int monkBloodCount = 0;//количество крови у монахов
    private GameObject selectedLizardSpawn;//домик из которого спавнить

    [SerializeField]
    private GameObject lizard;
    //префаб лизарда для спавна

    [SerializeField]
    private GameObject monk;
    //префаб монаха для спавнв
    [SerializeField]
    
    private GameObject bloodBottle;
    //префаб бытылки с кровью для спавна бутылок
    [SerializeField]
    private GameObject lizardCarrier;
    // префаб несуна лизардов для спавна
    [SerializeField]
    private GameObject monkCarrier;
    //префаб несуна монахов для спавна
    
    [SerializeField]
    private TMP_Text lizardBloodText;
    //элемент для отображения крови лизардов
    [SerializeField]
    private TMP_Text monkBloodText;
    //элемент для отображения крови монахов
    [SerializeField]
    private Transform monkHouse;
    //место спавна монахов НУЖНО ИСПРАВЛЯТЬ
    void Start() {
        bloodLay = new List<GameObject>();
        bloodCarry = new List<GameObject>();
        bloodRun = new List<GameObject>();

    }


    void FixedUpdate() {
        lizardSpawn = GameObject.FindGameObjectsWithTag("LizardSpawnPoint");//найти все домики лизардов
        foreach(GameObject item in lizardSpawn) {//  найти выбранный домик
            if (item.GetComponent<selector>().IsSelected()) {
                selectedLizardSpawn = item;//запомнить выбранный домик для определения места спавна
            }
        }
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
            //решить проблему с несунами!!!!
            GameObject newCarrier1 = Instantiate(monkCarrier, monkHouse.position, monkHouse.rotation);
            newCarrier1.GetComponent<MonkCarrierController>().setBottleToRun(bottle);
            bottle.GetComponent<BloodBottleController>().SetBottleState("run");
            
            GameObject newCarrier2 = Instantiate(lizardCarrier, selectedLizardSpawn.transform.position, selectedLizardSpawn.transform.rotation);
            newCarrier2.GetComponent<LizardCarrierController>().setBottleToRun(bottle);
            bottle.GetComponent<BloodBottleController>().SetBottleState("run");
        }
    }
    public GameObject[] GetAllSpawnPoints() {
        return lizardSpawn;
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
            //спавним лизарда из выбранного домика:
            //какой домик выбран
            //спавн лизарда
            Instantiate(lizard,selectedLizardSpawn.transform.position,selectedLizardSpawn.transform.rotation);
            RemoveLizardBloodCount(1);
        }
    }
    //спавн монков. Доработать определение места спавна
    public void MonkSpawn() {
        if (monkBloodCount > 0) {
            Instantiate(monk, monkHouse.position, monkHouse.rotation);
            RemoveMonkBloodCount(1);
        }
    }
    //подсчет крови
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
