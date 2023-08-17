using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public Animator doorAnim;

    [Header("Animation Names")]
    [SerializeField] private string openAnimationName = "DoorOpen";

    [SerializeField] private int waitTimer = 3;
    //[SerializeField] private bool pauseInteraction = false;

    [SerializeField] private bool PlayOnce = false;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            Debug.Log("Player is in range of Door");
            if (!PlayOnce)
            {
                doorAnim.Play(openAnimationName, 0, 0.0f);
                Debug.Log("Door Is Open");
                PlayOnce = true;
                Debug.Log("PlayOnce is : " + PlayOnce);
                StartCoroutine(PauseDoorInteraction());
            }
        }
    }
    private IEnumerator PauseDoorInteraction()
    {
        //pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        doorAnim.SetTrigger("Start");
        Debug.Log("Door Is Closed");
        PlayOnce = false;
        Debug.Log("PlayOnce is : " + PlayOnce);
        //pauseInteraction = false;
    }
}
