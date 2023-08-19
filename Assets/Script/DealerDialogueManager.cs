/*
 * Author: Jae Ng Ky Earn
 * Date: 8/19/2023
 * Description: The DealerDialogueManager class is used for control of car dealership NPC dialogue
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

namespace CollectionSystem
{
    public class DealerDialogueManager : MonoBehaviour
    {
        /// <summary>
        /// to have Player game object assigned in inspector
        /// </summary>
        public Player playerScript;

        /// <summary>
        /// to have NPC dialogue object assigned in inspector
        /// </summary>
        public NPC Dealer;

        /// <summary>
        /// bool to determine whether NPC is being spoken to
        /// </summary>
        bool isTalking = false;

        /// <summary>
        /// float to check distance between player and NPC
        /// </summary>
        private float distance;

        /// <summary>
        /// to have Player game object assigned in inspector
        /// </summary>
        public GameObject player;

        /// <summary>
        /// to have dialogue UI assigned in inspector
        /// </summary>
        public GameObject dialogueUI;

        /// <summary>
        /// to have NPC name text assigned in inspector
        /// </summary>
        public TextMeshProUGUI npcName;

        /// <summary>
        /// to have NPC dialogue text assigned in inspector
        /// </summary>
        public TextMeshProUGUI npcDialogueBox;

        /// <summary>
        /// to have NPC player response text assigned in inspector
        /// </summary>
        public TextMeshProUGUI playerResponse;

        /// <summary>
        /// to have shop menu UI assigned in inspector
        /// </summary>
        public GameObject Dealer_UI;

        // Start is called before the first frame update
        void Start()
        {
            dialogueUI.SetActive(false);
        }

        void OnMouseOver()
        {
            distance = Vector3.Distance(player.transform.position, this.transform.position);
            if (distance <= 3f)
            {
                //dialogue triggers
                if (Input.GetKeyDown(KeyCode.E) && isTalking == false)
                {
                    LookAtPlayer();
                    StartConversation();
                }

                // end dialogue
                else if (Input.GetKeyDown(KeyCode.E) && isTalking == true)
                {
                    EndDialogue();
                }

                // dealer dialogue
                if (npcDialogueBox.text == Dealer.dialogue[0])
                {
                    playerResponse.text = Dealer.playerDialogue[0];
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        npcDialogueBox.text = Dealer.dialogue[1];
                    }
                }

                else if (npcDialogueBox.text == Dealer.dialogue[1])
                {
                    playerScript.PlayerMovement = false;
                    Dealer_UI.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    npcDialogueBox.text = Dealer.dialogue[2];
                }

                else if (npcDialogueBox.text == Dealer.dialogue[2])
                {
                    playerResponse.text = Dealer.playerDialogue[0];
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        npcDialogueBox.text = Dealer.dialogue[3];
                    }
                }

                else if (npcDialogueBox.text == Dealer.dialogue[3] && Input.GetKeyDown(KeyCode.Space))
                {
                    EndDialogue();
                }
            }
        }

        /// <summary>
        /// function to start dialogue with the car dealer
        /// </summary>
        void StartConversation()
        {
            playerScript.PlayerMovement = false;

            isTalking = true;
            dialogueUI.SetActive(true);
            npcName.text = Dealer.name;
            npcDialogueBox.text = Dealer.dialogue[0];
        }

        /// <summary>
        /// function to end dialogue with the car dealer
        /// </summary>
        void EndDialogue()
        {
            isTalking = false;
            dialogueUI.SetActive(false);

            playerScript.PlayerMovement = true;
        }

        /// <summary>
        /// function to make NPC look at player when spoken to
        /// </summary>
        void LookAtPlayer()
        {
            transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}



