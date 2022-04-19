using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ИИ за врага
public class SpawnCintroller : MonoBehaviour {
    [SerializeField]
    GameObject lizardPrefab;
    [SerializeField]
    GameObject monkPrefab;
    [SerializeField]
    Transform lizardHouse;
    [SerializeField]
    Transform[] monkHouse;
    [SerializeField]
    GameController gameController;
    void Start() {
        InvokeRepeating("MonkSpawn", 1f, 0.5f);
    }
    // Update is called once per frame
    void Update() {
    }
    void MonkSpawn() {
        if (gameController.GetMonkBloodCount() > 0) {
            if (Random.value > 0.5) {
                Instantiate(monkPrefab, monkHouse[0].position, monkHouse[0].rotation);
            } else {
                Instantiate(monkPrefab, monkHouse[1].position, monkHouse[1].rotation);
            }
            gameController.RemoveMonkBloodCount(1);
        }
    }
}
