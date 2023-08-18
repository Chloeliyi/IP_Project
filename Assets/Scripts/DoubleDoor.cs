using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoor : MonoBehaviour
{
    /// <summary>
    /// Animator for the door animator
    /// </summary>
    public Animator animator1;
    public Animator animator2;

    /// <summary>
    /// When player enter trigger enter area door open
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator1.SetBool("IsOpen", true);
            animator2.SetBool("IsOpen", true);
           
        }
    }

    /// <summary>
    /// When player exit trigger area the door close
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator1.SetBool("IsOpen", false);
            animator2.SetBool("IsOpen", false);
        }
    }
}