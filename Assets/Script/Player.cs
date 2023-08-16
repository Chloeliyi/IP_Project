using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CollectionSystem
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour
    {
        public Camera playerCamera;
        public float walkSpeed = 1f;
        public float runSpeed = 3f;
        public float jumpPower = 4f;
        public float gravity = 10f;

        public float lookSpeed = 2f;
        public float lookXLimit = 45f;

        //[SerializeField] private int Test = 0;

        Vector3 moveDirection = Vector3.zero;
        float rotationX = 0;

        public bool canMove = true;

        public bool PlayerMovement = true;

        CharacterController characterController;
        // Start is called before the first frame update
        void Start()
        {
            characterController = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            //Debug.Log("This is Test " + Test);
        }

        // Update is called once per frame
        void Update()
        {
            if (PlayerMovement)
            {
                //Movement
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Vector3 right = transform.TransformDirection(Vector3.right);

                bool isRunning = Input.GetKey(KeyCode.LeftShift);
                float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
                float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
                float movementDirectionY = moveDirection.y;
                moveDirection = (forward * curSpeedX) + (right * curSpeedY);

                //Jumping
                if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
                {
                    moveDirection.y = jumpPower;
                }
                else
                {
                    moveDirection.y = movementDirectionY;
                }
                if (!characterController.isGrounded)
                {
                    moveDirection.y -= gravity * Time.deltaTime;
                }
                //Rotation
                characterController.Move(moveDirection * Time.deltaTime);

                if (canMove)
                {
                    rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                    rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                    playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                    transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
                }

                /*if (Input.GetKey(KeyCode.Escape))
                {
                    Debug.Log("Quit");
                    Application.Quit();
                }*/
            }
        }
    }
}
