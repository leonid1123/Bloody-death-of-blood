using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//отвечает только за старт игры, выбор стороны
public class StartController : MonoBehaviour {
    [SerializeField]
    private Canvas startScreen;
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private GameObject lizardButton;
    
    [SerializeField]
    private GameObject monkButton;
    private void Awake() {
        lizardButton.SetActive(false);
        monkButton.SetActive(false);
    }
    public void DeathOfAll() {
        GameObject[] prey1 = GameObject.FindGameObjectsWithTag("Lizard");
        GameObject[] prey2 = GameObject.FindGameObjectsWithTag("Monk");
        GameObject[] wastedBlood = GameObject.FindGameObjectsWithTag("Blood");
        for (int i = 0; i < prey1.Length; i++) {
            Destroy(prey1[i]);
        }
        for (int i = 0; i < prey2.Length; i++) {
            Destroy(prey2[i]);
        }
        for (int i = 0; i < wastedBlood.Length; i++) {
            Destroy(wastedBlood[i]);
        }
        //дать ресурсы
        gameController.GetComponent<GameController>().AddLizardBloodCount(5);
        gameController.GetComponent<GameController>().AddMonkBloodCount(5);
       
        //показать кнопки
        lizardButton.SetActive(true);
        //убрать канву
        startScreen.enabled = false;

    }
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
