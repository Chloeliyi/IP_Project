using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Chloe Chan
public class PlaySlideDoors : MonoBehaviour
{
    //Pay slide door animation
    public Animator SlidedoorAnim;

    [Header("Animation Names")]
    [SerializeField] private string openAnimationName = "SlideDoorsOpen";

    [SerializeField] private int waitTimer = 3;

    [SerializeField] private bool PlayOnce = false;

    private void Awake()
    {
        SlidedoorAnim = gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player" || coll.tag == "NPC")
        {
            Debug.Log("Player is in range of Door");
            if (!PlayOnce)
            {
                SlidedoorAnim.Play(openAnimationName, 0, 0.0f);
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
        SlidedoorAnim.SetTrigger("Start");
        Debug.Log("Door Is Closed");
        PlayOnce = false;
        Debug.Log("PlayOnce is : " + PlayOnce);
        //pauseInteraction = false;
    }
}
