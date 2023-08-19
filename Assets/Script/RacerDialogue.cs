using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

namespace CollectionSystem
{
    public class RacerDialogue : MonoBehaviour
    {
        public Player playerScript;

        public NPC Race;

        bool isTalking = false;

        private float distance;

        public GameObject player;
        public GameObject dialogueUI;

        public TextMeshProUGUI npcName;
        public TextMeshProUGUI npcDialogueBox;
        public TextMeshProUGUI playerResponse;

        public Transform teleportTarget, Targetplayer;
        public GameObject thePlayer;

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

                //race dialogue
                if (npcDialogueBox.text == Race.dialogue[0])
                {
                    playerResponse.text = Race.playerDialogue[0];
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        npcDialogueBox.text = Race.dialogue[1];
                    }
                }

                else if (npcDialogueBox.text == Race.dialogue[1])
                {
                    playerResponse.text = Race.playerDialogue[0];
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        npcDialogueBox.text = Race.dialogue[2];
                        // code to bring player to race track
                    }
                }

                else if (npcDialogueBox.text == Race.dialogue[2] && Input.GetKeyDown(KeyCode.Space))
                {
                    EndDialogue();
                    thePlayer.SetActive(false);
                    Targetplayer.position = teleportTarget.position;
                    Targetplayer.transform.rotation = teleportTarget.rotation;
                    thePlayer.SetActive(true);
                }
            }
        }

        void StartConversation()
        {
            playerScript.PlayerMovement = false;

            isTalking = true;
            dialogueUI.SetActive(true);
            npcName.text = Race.name;
            npcDialogueBox.text = Race.dialogue[0];
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

        }
    }
}

