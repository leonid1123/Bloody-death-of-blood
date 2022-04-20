using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkCarrierController : MonoBehaviour {
    private GameObject bottleToRun = null;
    private int myState = 1; //0-ждать, 1- бежать к бутылке, 2 - нести бутылку домой
    private int monkCarrierHP = 7;
    private float distanceToBottle;
    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private Transform monkHouse;
    private GameController gameController;
    public void setBottleToRun(GameObject _bottleToRun) {
        bottleToRun = _bottleToRun;
    }
    private void Start() {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    private void Update() {
        if (myState == 0) {
            rb2d.AddForce((monkHouse.transform.position - transform.position).normalized);
            if (Vector2.Distance(monkHouse.position, transform.position) <= 0.2f) {
                Destroy(gameObject);
            }
        }
        if (bottleToRun != null && myState == 1) {
            rb2d.AddForce((bottleToRun.transform.position - transform.position).normalized);
            distanceToBottle = Vector2.Distance(transform.position, bottleToRun.transform.position);
            if (distanceToBottle <= 0.1f) {
                myState = 2;
            }
            if (bottleToRun.GetComponent<BloodBottleController>().GetBottleState() != "run") {
                myState = 0;
            }
        }
        if (myState == 2) {
            bottleToRun.GetComponent<BloodBottleController>().SetBottleState("carry");
            rb2d.AddForce((monkHouse.position - transform.position).normalized);
            if (Vector2.Distance(monkHouse.position, transform.position) <= 0.2f) {
                gameController.AddMonkBloodCount(1);
                Destroy(bottleToRun);
                Destroy(gameObject);
            }
            if (bottleToRun != null) {
                bottleToRun.transform.position = transform.position;
            }
        }
    }
    public void TakeDamage(int _dmg) {
        monkCarrierHP -= _dmg;
        if (monkCarrierHP <= 0) {
            if (bottleToRun != null) {
                bottleToRun.GetComponent<BloodBottleController>().SetBottleState("lay");

            }
            //спавнить несуна
            Destroy(gameObject);
        }
    }
}
