using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject bloodBottle;

 private void OnDestroy() {
     Instantiate(bloodBottle,transform.position,transform.rotation);
 }
}
