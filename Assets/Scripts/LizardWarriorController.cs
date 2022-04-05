using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardWarriorController : MonoBehaviour {
    [SerializeField]
    private GameObject bloodBottle;
    [SerializeField]
    private GameObject lizardCarrier;
    [SerializeField]
    private Transform lizardHouse;
    private GameObject[] allEnemyes;
    [SerializeField]
    private GameObject lizardBlood;
    public Animator anim;
    public Rigidbody2D rb2d;
    private int lizardHp = 80;
    public GameObject enemy1;
    void Update() {
        allEnemyes = GameObject.Find("GameController").GetComponent<GameController>().GetMonks();
        if (allEnemyes!=null && allEnemyes.Length > 0) {
            enemy1 = WhoToKill(allEnemyes);
            RunToEnemy(enemy1);
        }
        if (Input.GetKeyDown(KeyCode.K)) {
            TakeDamage(81);
        }
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
            if (dstMin < 0.4f) {
                AttackEnemy("killkillkill");
            }
            if (dstMin > 0.4f) {
                AttackEnemy("runrunrun");
            }
        }
        return KILL;
    }
    void RunToEnemy(GameObject _enemy1) {
        if (_enemy1 != null) {
            rb2d.AddForce((_enemy1.transform.position - transform.position).normalized);
        }
    }
    void AttackEnemy(string _beh) {
        if (_beh == "killkillkill") {
            anim.SetBool("isAtk", true);
            //enemy1.GetComponent<MonkWarriorController>().TakeDamage(1);
        } else if (_beh == "runrunrun") {
            anim.SetBool("isAtk", false);
        }
    }
    public void TakeDamage(int _dmg) {
        lizardHp -= _dmg;
        GameObject hit = Instantiate(lizardBlood, transform.position, transform.rotation);
        Destroy(hit, 0.5f);
        if (lizardHp <= 0) {
            //заспавнить лужу крови
            //заспавнить бутылку с кровью
            //заспавнить бегунов
            GameObject newBottle = Instantiate(bloodBottle, transform.position, transform.rotation);
            GameObject newCarrier1 = Instantiate(lizardCarrier, lizardHouse.position, lizardHouse.rotation);
            newCarrier1.GetComponent<LizardCarrierController>().setBottleToRun(newBottle);
            Destroy(gameObject);
        }
    }
    public void InflictDamage(int _dmg) {
        enemy1.GetComponent<MonkWarriorController>().TakeDamage(_dmg);
    }
}
