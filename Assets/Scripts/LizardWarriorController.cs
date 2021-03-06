using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardWarriorController : MonoBehaviour {
    [SerializeField]
    private Transform lizardHouse;
    private GameObject[] allEnemyes;
    [SerializeField]
    private GameObject lizardBlood;
    [SerializeField]
    private GameObject bloodBottle;
    public Animator anim;
    public Rigidbody2D rb2d;
    private int lizardHp = 80;
    public GameObject enemy1;
    void Update() {
        allEnemyes = GameObject.Find("GameController").GetComponent<GameController>().GetMonks();
        if (allEnemyes != null && allEnemyes.Length > 0) {
            enemy1 = WhoToKill(allEnemyes);
            RunToEnemy(enemy1);
        }
        if (Input.GetKeyDown(KeyCode.K)) {
            TakeDamage(81);
        }
        float dir = transform.position.x - enemy1.transform.position.x;
        if (dir > 0) {
            //враг слева угол поворота 180
            transform.rotation = Quaternion.Euler(0, 180, 0);

        } else {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    public GameObject WhoToKill(GameObject[] _allEnemyes) {//async
        float dstMin = float.PositiveInfinity;
        GameObject KILL = _allEnemyes[0];
        foreach (GameObject i in _allEnemyes) {
            if (i == null) { break; }
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
            newBottle.GetComponent<BloodBottleController>().SetBottleState("lay");
            Destroy(gameObject);
        }
    }
    public void InflictDamage(int _dmg) {
        if (enemy1 == null) return;
        if (enemy1.name.Contains("Carrier")) {
            enemy1.GetComponent<MonkCarrierController>().TakeDamage(_dmg);
        } else {
            enemy1.GetComponent<MonkWarriorController>().TakeDamage(_dmg);
        }
    }
}
