using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardCarrierController : MonoBehaviour {
    private GameObject bottleToRun = null;
    private int myState = 1; //0-ждать, 1- бежать к бутылке, 2 - нести бутылку домой
    private int lizardCarrierHP = 7;
    private float distanceToBottle;
    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private Transform lizardHouse;
    private GameController gameController;
    public void setBottleToRun(GameObject _bottleToRun) {
        bottleToRun = _bottleToRun;
    }
    private void Start() {
        gameController=GameObject.Find("GameController").GetComponent<GameController>();
    }
    private void Update() {
        if (bottleToRun != null && myState == 1) {
            rb2d.AddForce((bottleToRun.transform.position - transform.position).normalized);
            distanceToBottle = Vector2.Distance(transform.position, bottleToRun.transform.position);
            if (distanceToBottle <= 0.1f) {
                myState = 2;
            }
        }
        if (myState == 2) {
            bottleToRun.GetComponent<BloodBottleController>().SetBottleState("carry");
            rb2d.AddForce((lizardHouse.position - transform.position).normalized);
            if (Vector2.Distance(lizardHouse.position,transform.position)<=0.2f) {
                gameController.AddLizardBloodCount(1);
                Destroy(gameObject);
                Destroy(bottleToRun);
            }
            if (bottleToRun != null) {
                bottleToRun.transform.position = transform.position;
            }
        }
    }
    public void TakeDamage(int _dmg) {
        lizardCarrierHP-=_dmg;
        if (lizardCarrierHP<=0) {
            bottleToRun.GetComponent<BloodBottleController>().SetBottleState("lay");
            //спавнить несуна
            Destroy(gameObject);
        }
    }
}
/*
есть ли приоритет в убийстве несунов?
какая логика определения цели воина: воин-несун?
палец бога?

количество несунов равно количеству бутылок
если есть бутылка спавнить несуна
у несуна 3 состояния: ждёт, бежит за бутылкой, несет бутылку
у бутылки 3 состояния: лежит, за ней бежит свой несун, её несут

несун бежит за ближейшей бутылкой за которой не бежит свой несун

если бутылка пропала(её подобрал враг или свой) несун ждёт

*/
