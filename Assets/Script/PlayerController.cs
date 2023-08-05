using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// movement Input 
    /// </summary>
    Vector3 movementInput = Vector3.zero;
    /// <summary>
    /// Movement Speed
    /// </summary>
    float movementSpeed = 0.07f;
    /// <summary>
    /// Rotation input
    /// </summary>
    Vector3 rotationInput = Vector3.zero;
    /// <summary>
    /// Rotation Speed
    /// </summary>
    float rotationSpeed = 1f;
    /// <summary>
    /// Roatation of camera Input
    /// </summary>
    Vector3 headRotationInput = Vector3.zero;
    /// <summary>
    /// Jump Streght
    /// </summary>
    public float jumpStrenght = 5f;
    /// <summary>
    /// GameObject that find player camera
    /// </summary>
    public GameObject playerCamera;
    /// <summary>
    /// Head of the player aka camera
    /// </summary>
    public Transform head;
    /// <summary>
    /// Sprint speed
    /// </summary>
    public float sprintModifier = 0.09f;
    /// <summary>
    /// bool that check if player is on ground
    /// </summary>
    private bool isGrounded = false;
    /// <summary>
    /// bool checks for mouse clicks
    /// </summary>
    bool mouseclick = false;



    /// <summary>
    /// Check if player is on the ground
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay(Collision collision)

    {
        isGrounded = true;
        //Debug.Log("Im grounded");// to test if player is grounded
    }

 
 
    void OnFire()
    {
        mouseclick = true;
    }
    /// <summary>
    /// player input actions that tracks player rotation 
    /// </summary>
    void OnLook(InputValue value)
    {
        rotationInput.y = value.Get<Vector2>().x;
        headRotationInput.x = -value.Get<Vector2>().y;
    }
    /// <summary>
    /// player input actions that tracks player movement
    /// </summary>
    void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();

    }
    /// <summary>
    /// player input actions that tracks player spacebar
    /// </summary>
    void OnJump()  //space to jump
    {
        if (isGrounded == true)
        {
            GetComponent<Rigidbody>().AddForce
            (Vector3.up * jumpStrenght, ForceMode.Impulse); //Lets player jump
        }
    }
   
    void Start()
    { 
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// update function
    /// </summary>
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = sprintModifier;
        }
        else
        {
            movementSpeed = 0.07f;
        }

        // Player movement
        Vector3 forwardDir = transform.forward;
       forwardDir *= movementInput.y;

        Vector3 rightDir = transform.right;
        rightDir *= movementInput.x;

        GetComponent<Rigidbody>().MovePosition(transform.position + (forwardDir + rightDir) * movementSpeed);
        //transform.position += (forwardDir + rightDir) * movementSpeed;




        // FOr player to look left and right
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + rotationInput * rotationSpeed);


        // For Player to look up and down
        var headRot = playerCamera.transform.rotation.eulerAngles
                + headRotationInput * rotationSpeed;

            //limitations for the player camera
        headRotationInput.x -= rotationInput.y;
        headRotationInput.x = Mathf.Clamp(headRotationInput.x, -45f, 45f);


        playerCamera.transform.rotation = Quaternion.Euler(headRot);

        isGrounded = false;

       

    }
}
