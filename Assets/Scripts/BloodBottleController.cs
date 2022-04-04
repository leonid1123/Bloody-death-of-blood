using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBottleController : MonoBehaviour
{
    private string state="lay"; //lay, run, carry
    public string GetBottleState() {
        return state;
    }
    public void SetBottleState(string _state){
        state = _state;
    }
    private void Start() {
        Destroy(gameObject,10f);
    }
}
