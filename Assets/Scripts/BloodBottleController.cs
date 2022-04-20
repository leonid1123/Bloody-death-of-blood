using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBottleController : MonoBehaviour
{
    private string state="lay"; //lay, lizardRun/monkRun, carry

    public string GetBottleState() {
        return state;
    }
    public void SetBottleState(string _state){
        state = _state;
    }
    private void Start() {
        Invoke("DestroySelf",10f);
    }
    private void DestroySelf() {
        Destroy(gameObject);
    }
    private void Update() {
        if (state=="carry") {
            CancelInvoke("DestroySelf");
        }
    }
}
