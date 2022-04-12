using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCintroller : MonoBehaviour {
    [SerializeField]
    GameObject lizardPrefab;
    [SerializeField]
    GameObject monkPrefab;
    [SerializeField]
    Transform lizardHouse;
    [SerializeField]
    Transform monkHouse;
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
            Instantiate(monkPrefab, monkHouse.position, monkHouse.rotation);
            gameController.RemoveMonkBloodCount(1);
        }
    }
}
