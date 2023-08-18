using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    /// <summary>
    /// Animator for the door animator
    /// </summary>
    public Animator animator;

    /// <summary>
    /// When player enter trigger enter area door open
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag== "")
        {
            animator.SetBool("isOpen", true);
           
        }
        else
        {
            Debug.Log("You cannot exit. Grab your helmet and gun.");
        }
    }

    /// <summary>
    /// When player exit trigger area the door close
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "")
        {
            animator.SetBool("isOpen", false);
        }
    }
}
