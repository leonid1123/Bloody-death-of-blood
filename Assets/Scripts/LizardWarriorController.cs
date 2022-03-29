using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardWarriorController : MonoBehaviour {

    private GameObject[] allEnemyes;
    public Animator anim;
    void Start() {

    }
    void Update() {
        allEnemyes = GameObject.Find("GameController").GetComponent<GameController>().GetMonks();
        Debug.Log(allEnemyes.Length);
        GameObject enemy1 = WhoToKill(allEnemyes);
        RunToEnemy(enemy1);
        
    }
    public GameObject WhoToKill(GameObject[] _allEnemyes) {//async
        float dstMin = float.PositiveInfinity;
        GameObject KILL = _allEnemyes[0];
        foreach (GameObject i in _allEnemyes) {
            float kt = Vector2.Distance(transform.position, i.transform.position);
            if (kt < dstMin) {
                dstMin = kt;
                KILL = i;
            }
            if (dstMin<0.1f) {
                AttackEnemy();
            }
        }
        return KILL;
    }
    void RunToEnemy(GameObject _enemy1) {
        transform.Translate((_enemy1.transform.position - transform.position).normalized * Time.deltaTime, Space.World);
    }
    void AttackEnemy() {

    }
}
