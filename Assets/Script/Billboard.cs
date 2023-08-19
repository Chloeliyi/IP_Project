/*
 * Author: Chloe Chan
 * Date: 8/19/2023
 * Description: The billboard for making the object look at player camera
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    /// <summary>
    /// Camera transform
    /// </summary>
    public Transform Camera;

    void LateUpdate()
    {
        transform.LookAt(transform.position + Camera.forward);
    }
}
