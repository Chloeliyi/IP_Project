using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

namespace CollectionSystem
{
    public class DialogueManager : MonoBehaviour
    {
        public PlayerScript playerScript;
        public Player _Player;

        public NPC npc;

        bool isTalking = false;

        float distance;
        float currentResponseTracker = 0;

        public GameObject player;
        public GameObject dialogueUI;

        public TextMeshProUGUI npcName;
        public TextMeshProUGUI npcDialogueBox;
        public TextMeshProUGUI playerResponse;

        private QuestController _Quest;
        // Start is called before the first frame update
        void Start()
        {
            dialogueUI.SetActive(false);
        }

        void OnMouseOver()
        {
            distance = Vector3.Distance(player.transform.position, this.transform.position);
            if (distance <= 2.5f)
            {
                /*
                if(Input.GetKeyDown(KeyCode.Alpha2))
                {
                    currentResponseTracker++;
                    if(currentResponseTracker >= npc.playerDialogue.Length - 1)
                    {
                        currentResponseTracker = npc.playerDialogue.Length - 1;
                    }
                }

                else if(Input.GetKeyDown(KeyCode.Alpha2))
                {
                    currentResponseTracker--;
                    if(currentResponseTracker < 0)
                    {
                        currentResponseTracker = 0;
                    }
                }
                */

                //trigger dialogue
                if (Input.GetKeyDown(KeyCode.E) && isTalking == false)
                {
                    Debug.Log("Conversation start");
                    StartConversation();
                    //playerScript.playermovement = false;
                    _Player.PlayerMovement = false;

                    Debug.Log(_Player.PlayerMovement);
                }

                else if (Input.GetKeyDown(KeyCode.E) && isTalking == true)
                {
                    Debug.Log("Conversation end");
                    EndDialogue();
                    //playerScript.playermovement = true;
                    _Player.PlayerMovement = true;

                    Debug.Log(_Player.PlayerMovement);
                }

                if (currentResponseTracker == 0 && npc.playerDialogue.Length >= 0)
                {
                    playerResponse.text = npc.playerDialogue[0];
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        npcDialogueBox.text = npc.dialogue[1];
                        currentResponseTracker = npc.playerDialogue.Length - 1;
                    }
                }

                else if (currentResponseTracker == 1 && npc.playerDialogue.Length >= 1)
                {
                    playerResponse.text = npc.playerDialogue[1];
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        npcDialogueBox.text = npc.dialogue[2];
                        currentResponseTracker = npc.playerDialogue.Length - 1;
                    }
                }
            }
        }

        void StartConversation()
        {
            isTalking = true;
            currentResponseTracker = 0;
            dialogueUI.SetActive(true);
            npcName.text = npc.name;
            npcDialogueBox.text = npc.dialogue[0];
        }

        void EndDialogue()
        {
            isTalking = false;
            dialogueUI.SetActive(false);
            QuestController.instance.QuestCounted();

    }
}
}
