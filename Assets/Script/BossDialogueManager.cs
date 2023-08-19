/*
 * Author: Jae Ng Ky Earn
 * Date: 8/19/2023
 * Description: The BossDialogueManager class is used for control of garage boss NPC dialogue
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AI;

namespace CollectionSystem
{
    public class BossDialogueManager : MonoBehaviour
    {
        /// <summary>
        /// to have Player game object assigned in inspector
        /// </summary>
        public Player playerScript;

        /// <summary>
        /// to have tutorial dialogue object assigned in inspector
        /// </summary>
        public NPC Tutorial;

        /// <summary>
        /// bool to determine whether NPC is being spoken to
        /// </summary>
        bool isTalking = false;

        /// <summary>
        /// bool to determine whether task 1 is ongoing
        /// </summary>
        public bool task1Ongoing = false;

        /// <summary>
        /// bool to determine whether task 1 is complete
        /// </summary>
        public bool task1Complete = false;

        /// <summary>
        /// bool to determine whether task 2 is ongoing
        /// </summary>
        public bool task2Ongoing = false;

        /// <summary>
        /// bool to determine whether task 1 is complete
        /// </summary>
        public bool task2Complete = false;

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

        public NavMeshAgent agent;

        /// <summary>
        /// to have NPC NavMesh waypoints assigned in inspector
        /// </summary>
        public Transform[] waypoints; // Array of waypoint transforms

        /// <summary>
        /// int to keep track of which waypoint the NPC is currently on
        /// </summary>
        private int currentWaypointIndex = 0;

        /// <summary>
        /// to have the waypoint that the boss NPC despawns at assigned in inspector
        /// </summary>
        public Transform destroyBossHere;

        [SerializeField] private RandomSpawner ItemSpawn;
        [SerializeField] private CarAI _FirstCarAI;
        [SerializeField] private CarAI _SecondCarAI;

        // Start is called before the first frame update
        void Start()
        {
            dialogueUI.SetActive(false);
            agent = GetComponent<NavMeshAgent>();
        }

        void OnMouseOver()
        {
            distance = Vector3.Distance(player.transform.position, this.transform.position);
            if (distance <= 3f)
            {
                //dialogue triggers
                if (Input.GetKeyDown(KeyCode.E) && isTalking == false && currentWaypointIndex == 0)
                {
                    LookAtPlayer();
                    StartTutorialConversation();
                }

                else if (Input.GetKeyDown(KeyCode.E) && isTalking == false && currentWaypointIndex == 1)
                {
                    LookAtPlayer();
                    StartTutorialConversation();
                    npcDialogueBox.text = Tutorial.dialogue[3];
                }

                else if (Input.GetKeyDown(KeyCode.E) && isTalking == false && currentWaypointIndex == 2 && task1Ongoing == false && task1Complete == false)
                {
                    LookAtPlayer();
                    StartTutorialConversation();
                    npcDialogueBox.text = Tutorial.dialogue[6];
                }

                else if (Input.GetKeyDown(KeyCode.E) && isTalking == false && currentWaypointIndex == 2 && task1Ongoing == true && task1Complete == false)
                {
                    LookAtPlayer();
                    StartTutorialConversation();
                    npcDialogueBox.text = Tutorial.dialogue[8];
                }

                else if (Input.GetKeyDown(KeyCode.E) && isTalking == false && currentWaypointIndex == 2 && task1Ongoing == false && task1Complete == true)
                {
                    LookAtPlayer();
                    StartTutorialConversation();
                    npcDialogueBox.text = Tutorial.dialogue[9];
                }

                else if (Input.GetKeyDown(KeyCode.E) && isTalking == false && currentWaypointIndex == 3 && task2Ongoing == false && task2Complete == false)
                {
                    LookAtPlayer();
                    StartTutorialConversation();
                    npcDialogueBox.text = Tutorial.dialogue[10];
                }

                else if (Input.GetKeyDown(KeyCode.E) && isTalking == false && currentWaypointIndex == 3 && task2Ongoing == true && task2Complete == false)
                {
                    LookAtPlayer();
                    StartTutorialConversation();
                    npcDialogueBox.text = Tutorial.dialogue[11];
                }

                else if (Input.GetKeyDown(KeyCode.E) && isTalking == false && currentWaypointIndex == 3 && task2Ongoing == false && task2Complete == true)
                {
                    LookAtPlayer();
                    StartTutorialConversation();
                    npcDialogueBox.text = Tutorial.dialogue[12];
                }

                else if (Input.GetKeyDown(KeyCode.E) && isTalking == false && currentWaypointIndex == 4)
                {
                    LookAtPlayer();
                    StartTutorialConversation();
                    npcDialogueBox.text = Tutorial.dialogue[13];
                }

                //end dialogue
                else if (Input.GetKeyDown(KeyCode.E) && isTalking == true)
                {
                    EndDialogue();
                }

                //tutorial boss dialogue part 1
                if (npcDialogueBox.text == Tutorial.dialogue[0])
                {
                    playerResponse.text = Tutorial.playerDialogue[0];
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        npcDialogueBox.text = Tutorial.dialogue[1];
                    }
                }

                else if (npcDialogueBox.text == Tutorial.dialogue[1])
                {
                    playerResponse.text = Tutorial.playerDialogue[0];
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        npcDialogueBox.text = Tutorial.dialogue[2];
                    }
                }

                else if (npcDialogueBox.text == Tutorial.dialogue[2] && Input.GetKeyDown(KeyCode.Space))
                {
                    EndDialogue();
                    GoToNextWaypoint();
                }

                //tutorial boss dialogue part 2

                if (npcDialogueBox.text == Tutorial.dialogue[3])
                {
                    playerResponse.text = Tutorial.playerDialogue[0];
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        npcDialogueBox.text = Tutorial.dialogue[4];
                    }
                }

                else if (npcDialogueBox.text == Tutorial.dialogue[4])
                {
                    playerResponse.text = Tutorial.playerDialogue[0];
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        npcDialogueBox.text = Tutorial.dialogue[5];
                    }
                }

                else if (npcDialogueBox.text == Tutorial.dialogue[5] && Input.GetKeyDown(KeyCode.Space))
                {
                    EndDialogue();
                    GoToNextWaypoint();
                }

                //tutorial boss dialogue part 3

                if (npcDialogueBox.text == Tutorial.dialogue[6])
                {
                    playerResponse.text = Tutorial.playerDialogue[0];
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        npcDialogueBox.text = Tutorial.dialogue[7];
                    }
                }

                else if (npcDialogueBox.text == Tutorial.dialogue[7] && Input.GetKeyDown(KeyCode.Space))
                {
                    task1Ongoing = true;
                    EndDialogue();
                }

                else if (npcDialogueBox.text == Tutorial.dialogue[8] && Input.GetKeyDown(KeyCode.Space))
                {
                    task1Ongoing = true;
                    EndDialogue();
                }

                else if (npcDialogueBox.text == Tutorial.dialogue[9] && Input.GetKeyDown(KeyCode.Space))
                {
                    EndDialogue();
                    GoToNextWaypoint();
                }

                //tutorial boss dialogue part 4

                if (npcDialogueBox.text == Tutorial.dialogue[10] && Input.GetKeyDown(KeyCode.Space))
                {
                    task2Ongoing = true;
                    EndDialogue();
                }

                else if (npcDialogueBox.text == Tutorial.dialogue[11] && Input.GetKeyDown(KeyCode.Space))
                {
                    task2Ongoing = true;
                    EndDialogue();
                }

                else if (npcDialogueBox.text == Tutorial.dialogue[12] && Input.GetKeyDown(KeyCode.Space))
                {
                    EndDialogue();
                    GoToNextWaypoint();
                }

                //tutorial boss dialogue part 5

                if (npcDialogueBox.text == Tutorial.dialogue[13])
                {
                    playerResponse.text = Tutorial.playerDialogue[0];
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        npcDialogueBox.text = Tutorial.dialogue[14];
                    }
                }

                else if (npcDialogueBox.text == Tutorial.dialogue[14])
                {
                    playerResponse.text = Tutorial.playerDialogue[0];
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        npcDialogueBox.text = Tutorial.dialogue[15];
                    }
                }

                else if (npcDialogueBox.text == Tutorial.dialogue[15])
                {
                    playerResponse.text = Tutorial.playerDialogue[0];
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        npcDialogueBox.text = Tutorial.dialogue[16];
                    }
                }

                else if (npcDialogueBox.text == Tutorial.dialogue[16])
                {
                    playerResponse.text = Tutorial.playerDialogue[0];
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        npcDialogueBox.text = Tutorial.dialogue[17];
                    }
                }

                else if (npcDialogueBox.text == Tutorial.dialogue[17])
                {
                    playerResponse.text = Tutorial.playerDialogue[0];
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        npcDialogueBox.text = Tutorial.dialogue[18];
                    }
                }

                else if (npcDialogueBox.text == Tutorial.dialogue[18])
                {
                    playerResponse.text = Tutorial.playerDialogue[0];
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        npcDialogueBox.text = Tutorial.dialogue[19];
                    }
                }

                else if (npcDialogueBox.text == Tutorial.dialogue[19])
                {
                    playerResponse.text = Tutorial.playerDialogue[0];
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        npcDialogueBox.text = Tutorial.dialogue[20];
                    }
                }

                else if (npcDialogueBox.text == Tutorial.dialogue[20])
                {
                    playerResponse.text = Tutorial.playerDialogue[0];
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        npcDialogueBox.text = Tutorial.dialogue[21];
                    }
                }

                else if (npcDialogueBox.text == Tutorial.dialogue[21] && Input.GetKeyDown(KeyCode.Space))
                {
                    EndDialogue();
                    GoToNextWaypoint();
                    QuestCounter();
                    SpawnItemsNow();

                    _FirstCarAI.RoamStart();
                    _SecondCarAI.RoamStart();
                }
            }
        }

        void GoToNextWaypoint()
        {
            if (waypoints.Length == 0)
            {
                Debug.LogError("No waypoints assigned for npc movement!");
                return;
            }

            agent.SetDestination(waypoints[currentWaypointIndex].position);
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }

        /// <summary>
        /// function to start tutorial dialogue with the garage boss
        /// </summary>
        void StartTutorialConversation()
        {
            playerScript.PlayerMovement = false;

            isTalking = true;
            dialogueUI.SetActive(true);
            npcName.text = Tutorial.name;
            npcDialogueBox.text = Tutorial.dialogue[0];
        }

        /// <summary>
        /// function to end tutorial dialogue with the garage boss
        /// </summary>
        void EndDialogue()
        {
            isTalking = false;
            dialogueUI.SetActive(false);

            playerScript.PlayerMovement = true;
        }
        /// <summary>
        /// function for quest number to increase after tutorial ends
        /// </summary>
        void QuestCounter()
        {
            QuestController.instance.QuestCounted();
        }

        /// <summary>
        /// function for spawning items after tutorial ends
        /// </summary>
        void SpawnItemsNow()
        {
            ItemSpawn.SpawnItemOneAtStart();
            ItemSpawn.SpawnItemTwoAtStart();
            ItemSpawn.SpawnItemThreeAtStart();
            ItemSpawn.SpawnItemFourAtStart();

        }

        /// <summary>
        /// function to make NPC look at player when spoken to
        /// </summary>
        void LookAtPlayer()
        {
            transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
        }

        void Update()
        {
            // despawns garage boss NPC when reaches final waypoint
            if (Vector3.Distance(transform.position, destroyBossHere.position) < 1f)
            {
                Destroy(gameObject);
            }
        }
    }
}