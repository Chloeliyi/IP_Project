using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Chloe Chan
namespace CollectionSystem
{
    public class Player : MonoBehaviour
    {
        public BossDialogueManager bossDialogueManager;

        public int task1CollectibleCount = 0;

        public float movementSpeed = 0.3f;

        public float sprintSpeed = 0.1f;

        public Image staminaBar;

        public Rigidbody rb;

        public bool PlayerMovement = true;

        bool sprint;

        public bool playerGrounded = true;

        public float jumpHeight = 5f;

        Vector3 movementInput = Vector3.zero;

        Vector3 horizontalInput = Vector3.zero;

        Vector3 verticalInput = Vector3.zero;

        public float mouseSensitivity = 0.1f;

        public Transform camera;

        [SerializeField] private GameObject PauseMenu;
        //Player walk animation
        public Animator PlayerAnim;

        void OnLook(InputValue value)
        {
            horizontalInput.y = value.Get<Vector2>().x;
            verticalInput.x = -value.Get<Vector2>().y;
            verticalInput.x = Mathf.Clamp(verticalInput.x, -90f, 90f);
        }

        /// <summary>
        /// function for registering shift on keyboard being pressed
        /// </summary>
        void OnSprintStart()
        {
            sprint = true;
        }

        /// <summary>
        /// function for registering shift on keyboard being let go
        /// </summary>
        void OnSprintStop()
        {
            sprint = false;
        }

        void Update()
        {
            if (PlayerMovement)
            {
                PlayerAnim.SetBool("m_walk", true);

                // Create a new Vector3
                Vector3 movementVector = Vector3.zero;

                // Add the forward direction of the player multiplied by the user's up/down input.
                movementVector += transform.forward * movementInput.y;

                // Add the right direction of the player multiplied by the user's right/left input.
                movementVector += transform.right * movementInput.x;

                // increases movement speed when sprint is held down
                if (sprint && staminaBar.fillAmount > 0)
                {
                    GetComponent<Rigidbody>().MovePosition(transform.position + ((transform.right * movementInput.x) + (transform.forward * movementInput.y)) * sprintSpeed);
                    staminaBar.fillAmount -= 0.25f * Time.deltaTime;
                }

                // reduces movement speed to normal walking speed when stamina runs out
                else if (sprint && staminaBar.fillAmount <= 0)
                {
                    GetComponent<Rigidbody>().MovePosition(transform.position + ((transform.right * movementInput.x) + (transform.forward * movementInput.y)) * movementSpeed);
                }

                // reduces movement speed to normal walking speed when shift key is not held down
                else if (!sprint && staminaBar.fillAmount >= 0)
                {
                    GetComponent<Rigidbody>().MovePosition(transform.position + ((transform.right * movementInput.x) + (transform.forward * movementInput.y)) * movementSpeed);
                    staminaBar.fillAmount += 0.35f * Time.deltaTime;
                }

                // jump
                if (Input.GetButtonDown("Jump") & playerGrounded)
                {
                    rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
                    playerGrounded = false;
                }

                // player look
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + horizontalInput * mouseSensitivity);
                camera.rotation = Quaternion.Euler(camera.rotation.eulerAngles + new Vector3(verticalInput.x, 0f, 0f) * mouseSensitivity);

                Cursor.lockState = CursorLockMode.Locked;
            }
            PlayerAnim.SetBool("m_walk", false);

            /*if (Input.GetKeyDown(KeyCode.Backspace)) {
                PlayerMovement = false;
                Cursor.lockState = CursorLockMode.None;
                PauseMenu.SetActive(true);
            }*/

            if(Input.GetKey(KeyCode.R))
            {
                Debug.Log("Quit");
                Application.Quit();
            }
        }

        /// <summary>
        /// Called when the Move action is detected.
        /// </summary>
        /// <param name="value"></param>
        void OnMove(InputValue value)
        {
            if (PlayerMovement)
            {
                movementInput = value.Get<Vector2>();
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            // for jump
            rb = GetComponent<Rigidbody>();
        }
        // Update is called once per frame

        //Press resume button on the pause menu
        public void OnResumeButton()
        {
            PlayerMovement = true;
            Cursor.lockState = CursorLockMode.Locked;
            PauseMenu.SetActive(false);
        }
    }
}

