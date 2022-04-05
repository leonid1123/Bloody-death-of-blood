using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardCarrierController : MonoBehaviour {
    private GameObject bottleToRun = null;
    private int myState = 1; //0-ждать, 1- бежать к бутылке, 2 - нести бутылку домой
    private float distanceToBottle;
    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private Transform lizardHouse;
    public void setBottleToRun(GameObject _bottleToRun) {
        bottleToRun = _bottleToRun;
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
            rb2d.AddForce((lizardHouse.position - transform.position).normalized);
            if (bottleToRun != null) {
                bottleToRun.transform.position = transform.position;
            }
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
