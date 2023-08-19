using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Jae Ng
public class LookAtObj : MonoBehaviour
{
    //NPC will look in the direction of player
    public GameObject _object;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _object.transform.position);
    }
}
