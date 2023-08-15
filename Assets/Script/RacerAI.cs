using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerAI : MonoBehaviour
{
    private string currentState;
    private string nextState;
    private void SwitchState()
    {
        StartCoroutine(currentState);
    }

    void Start()
    {
        currentState = "";
        nextState = currentState;
        SwitchState();
    }

    // Update is called once per frame
    void Update()
    {

        if (currentState != nextState)
        {
            currentState = nextState;
        }

    }

    IEnumerator OverTake()
    {
        yield return new WaitForSeconds(3);
        SwitchState();
    }

    IEnumerator FollowPlayer()
    {
        yield return new WaitForSeconds(3);
        SwitchState();
    }

    IEnumerator AvoidCollision()
    {
        yield return new WaitForSeconds(3);
        SwitchState();
    }

}
