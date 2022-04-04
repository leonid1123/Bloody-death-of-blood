using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardCarrierController : MonoBehaviour {
    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private Transform lizardHouse;
    private int myState = 1; //0-ждать, 1-за бутылкой, 2-домой
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        List<GameObject> allBlood = GameObject.Find("GameController").GetComponent<GameController>().GetLayBlood();
        if (allBlood.Count > 0) {//исчезает условие передвижения!!! написать нормально обработку собственных состояний
            float minDst = Mathf.Infinity;
            GameObject bottleToRun = null;
            foreach (GameObject blood in allBlood) {
                float dst = Vector2.Distance(transform.position, blood.transform.position);
                if (dst < minDst) {
                    dst = minDst;
                    bottleToRun = blood;
                }
            }
            if (Vector2.Distance(transform.position, bottleToRun.transform.position) <= 0.1f) {
                myState = 2;
                bottleToRun.GetComponent<BloodBottleController>().SetBottleState("carry");
            }

            if (myState == 1) {
                rb2d.AddForce((bottleToRun.transform.position - transform.position).normalized);
                Debug.Log("to bottle");
            }
            if (myState == 2) {
                rb2d.AddForce((lizardHouse.position - transform.position).normalized);
                Debug.Log("to home");
            }
            Debug.Log(myState);
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
