using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRace : MonoBehaviour
{
    public bool raceEnds = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "InteractiveObject")
        {
            Debug.Log("raceline passed");
            raceEnds = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
