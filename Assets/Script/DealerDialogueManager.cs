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
        public Player playerScript;

        public NPC Dealer;

        bool isTalking = false;

        private float distance;

        public GameObject player;
        public GameObject dialogueUI;

        public TextMeshProUGUI npcName;
        public TextMeshProUGUI npcDialogueBox;
        public TextMeshProUGUI playerResponse;

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
                //trigger dialogue
                if (Input.GetKeyDown(KeyCode.E) && isTalking == false)
                {
                    LookAtPlayer();
                    StartConversation();
                }

                //end dialogue
                else if (Input.GetKeyDown(KeyCode.E) && isTalking == true)
                {
                    EndDialogue();
                }

                //dealer dialogue
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

        void StartConversation()
        {
            playerScript.PlayerMovement = false;

            isTalking = true;
            dialogueUI.SetActive(true);
            npcName.text = Dealer.name;
            npcDialogueBox.text = Dealer.dialogue[0];
        }

        void EndDialogue()
        {
            isTalking = false;
            dialogueUI.SetActive(false);

            playerScript.PlayerMovement = true;
        }

        void LookAtPlayer()
        {
            transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(Cursor.lockState);
        }
    }
}

