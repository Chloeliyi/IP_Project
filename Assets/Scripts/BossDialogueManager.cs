using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AI;

public class BossDialogueManager : MonoBehaviour
{
    public PlayerScript playerScript;

    public NPC Tutorial;

    bool isTalking = false;
    public bool task1Ongoing = false;
    public bool task1Complete = false;
    public bool task2Ongoing = false;
    public bool task2Complete = false;

    private float distance;

    public GameObject player;
    public GameObject dialogueUI;

    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public TextMeshProUGUI playerResponse;

    public NavMeshAgent agent;
    public Transform[] waypoints; // Array of waypoint transforms
    private int currentWaypointIndex = 0;

    public Transform destroyBossHere;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
        agent = GetComponent<NavMeshAgent>();
    }

    void OnMouseOver()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if(distance <= 3f)
        {
            //trigger dialogue
            if(Input.GetKeyDown(KeyCode.E) && isTalking == false && currentWaypointIndex == 0)
            {
                LookAtPlayer();
                StartTutorialConversation();
            }

            else if(Input.GetKeyDown(KeyCode.E) && isTalking == false && currentWaypointIndex == 1)
            {
                LookAtPlayer();
                StartTutorialConversation();
                npcDialogueBox.text = Tutorial.dialogue[3];
            }

            else if(Input.GetKeyDown(KeyCode.E) && isTalking == false && currentWaypointIndex == 2 && task1Ongoing == false && task1Complete == false)
            {
                LookAtPlayer();
                StartTutorialConversation();
                npcDialogueBox.text = Tutorial.dialogue[6];
            }

            else if(Input.GetKeyDown(KeyCode.E) && isTalking == false && currentWaypointIndex == 2 && task1Ongoing == true && task1Complete == false)
            {
                LookAtPlayer();
                StartTutorialConversation();
                npcDialogueBox.text = Tutorial.dialogue[8];
            }

            else if(Input.GetKeyDown(KeyCode.E) && isTalking == false && currentWaypointIndex == 2 && task1Ongoing == false && task1Complete == true)
            {
                LookAtPlayer();
                StartTutorialConversation();
                npcDialogueBox.text = Tutorial.dialogue[9];
            }

            else if(Input.GetKeyDown(KeyCode.E) && isTalking == false && currentWaypointIndex == 3 && task2Ongoing == false && task2Complete == false)
            {
                LookAtPlayer();
                StartTutorialConversation();
                npcDialogueBox.text = Tutorial.dialogue[10];
            }

            else if(Input.GetKeyDown(KeyCode.E) && isTalking == false && currentWaypointIndex == 3 && task2Ongoing == true && task2Complete == false)
            {
                LookAtPlayer();
                StartTutorialConversation();
                npcDialogueBox.text = Tutorial.dialogue[11];
            }

            else if(Input.GetKeyDown(KeyCode.E) && isTalking == false && currentWaypointIndex == 3 && task2Ongoing == false && task2Complete == true)
            {
                LookAtPlayer();
                StartTutorialConversation();
                npcDialogueBox.text = Tutorial.dialogue[12];
            }

            else if(Input.GetKeyDown(KeyCode.E) && isTalking == false && currentWaypointIndex == 4)
            {
                LookAtPlayer();
                StartTutorialConversation();
                npcDialogueBox.text = Tutorial.dialogue[13];
            }

            //end dialogue
            else if(Input.GetKeyDown(KeyCode.E) && isTalking == true)
            {
                EndDialogue();
            }

            //tutorial boss dialogue part 1
            if(npcDialogueBox.text == Tutorial.dialogue[0])
            {
                playerResponse.text = Tutorial.playerDialogue[0];
                if(Input.GetKeyDown(KeyCode.Space))
                {   
                    npcDialogueBox.text = Tutorial.dialogue[1];
                }
            }

            else if(npcDialogueBox.text == Tutorial.dialogue[1])
            {
                playerResponse.text = Tutorial.playerDialogue[0];
                if(Input.GetKeyDown(KeyCode.Space))
                {   
                    npcDialogueBox.text = Tutorial.dialogue[2];
                }
            }

            else if(npcDialogueBox.text == Tutorial.dialogue[2] && Input.GetKeyDown(KeyCode.Space))
            {
                EndDialogue();
                GoToNextWaypoint();
            }
            
            //tutorial boss dialogue part 2

            if(npcDialogueBox.text == Tutorial.dialogue[3])
            {
                playerResponse.text = Tutorial.playerDialogue[0];
                if(Input.GetKeyDown(KeyCode.Space))
                {   
                    npcDialogueBox.text = Tutorial.dialogue[4];
                }
            }

            else if(npcDialogueBox.text == Tutorial.dialogue[4])
            {
                playerResponse.text = Tutorial.playerDialogue[0];
                if(Input.GetKeyDown(KeyCode.Space))
                {   
                    npcDialogueBox.text = Tutorial.dialogue[5];
                }
            }

            else if(npcDialogueBox.text == Tutorial.dialogue[5] && Input.GetKeyDown(KeyCode.Space))
            {
                EndDialogue();
                GoToNextWaypoint();
            }

            //tutorial boss dialogue part 3

            if(npcDialogueBox.text == Tutorial.dialogue[6])
            {
                playerResponse.text = Tutorial.playerDialogue[0];
                if(Input.GetKeyDown(KeyCode.Space))
                {   
                    npcDialogueBox.text = Tutorial.dialogue[7];
                }
            }

            else if(npcDialogueBox.text == Tutorial.dialogue[7] && Input.GetKeyDown(KeyCode.Space))
            {
                task1Ongoing = true;
                EndDialogue();
            }

            else if(npcDialogueBox.text == Tutorial.dialogue[8] && Input.GetKeyDown(KeyCode.Space))
            {
                task1Ongoing = true;
                EndDialogue();
            }

            else if(npcDialogueBox.text == Tutorial.dialogue[9] && Input.GetKeyDown(KeyCode.Space))
            {
                EndDialogue();
                GoToNextWaypoint();
            }

            //tutorial boss dialogue part 4

            if(npcDialogueBox.text == Tutorial.dialogue[10] && Input.GetKeyDown(KeyCode.Space))
            {
                task2Ongoing = true;
                EndDialogue();
            }

            else if(npcDialogueBox.text == Tutorial.dialogue[11] && Input.GetKeyDown(KeyCode.Space))
            {
                task2Ongoing = true;
                EndDialogue();
            }

            else if(npcDialogueBox.text == Tutorial.dialogue[12] && Input.GetKeyDown(KeyCode.Space))
            {
                EndDialogue();
                GoToNextWaypoint();
            }

            //tutorial boss dialogue part 5

            if(npcDialogueBox.text == Tutorial.dialogue[13])
            {
                playerResponse.text = Tutorial.playerDialogue[0];
                if(Input.GetKeyDown(KeyCode.Space))
                {   
                    npcDialogueBox.text = Tutorial.dialogue[14];
                }
            }

            else if(npcDialogueBox.text == Tutorial.dialogue[14])
            {
                playerResponse.text = Tutorial.playerDialogue[0];
                if(Input.GetKeyDown(KeyCode.Space))
                {   
                    npcDialogueBox.text = Tutorial.dialogue[15];
                }
            }

            else if(npcDialogueBox.text == Tutorial.dialogue[15])
            {
                playerResponse.text = Tutorial.playerDialogue[0];
                if(Input.GetKeyDown(KeyCode.Space))
                {   
                    npcDialogueBox.text = Tutorial.dialogue[16];
                }
            }

            else if(npcDialogueBox.text == Tutorial.dialogue[16])
            {
                playerResponse.text = Tutorial.playerDialogue[0];
                if(Input.GetKeyDown(KeyCode.Space))
                {   
                    npcDialogueBox.text = Tutorial.dialogue[17];
                }
            }

            else if(npcDialogueBox.text == Tutorial.dialogue[17])
            {
                playerResponse.text = Tutorial.playerDialogue[0];
                if(Input.GetKeyDown(KeyCode.Space))
                {   
                    npcDialogueBox.text = Tutorial.dialogue[18];
                }
            }

            else if(npcDialogueBox.text == Tutorial.dialogue[18])
            {
                playerResponse.text = Tutorial.playerDialogue[0];
                if(Input.GetKeyDown(KeyCode.Space))
                {   
                    npcDialogueBox.text = Tutorial.dialogue[19];
                }
            }

            else if(npcDialogueBox.text == Tutorial.dialogue[19])
            {
                playerResponse.text = Tutorial.playerDialogue[0];
                if(Input.GetKeyDown(KeyCode.Space))
                {   
                    npcDialogueBox.text = Tutorial.dialogue[20];
                }
            }

            else if(npcDialogueBox.text == Tutorial.dialogue[20])
            {
                playerResponse.text = Tutorial.playerDialogue[0];
                if(Input.GetKeyDown(KeyCode.Space))
                {   
                    npcDialogueBox.text = Tutorial.dialogue[21];
                }
            }

            else if(npcDialogueBox.text == Tutorial.dialogue[21] && Input.GetKeyDown(KeyCode.Space))
            {
                EndDialogue();
                GoToNextWaypoint();
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

    void StartTutorialConversation()
    {
        playerScript.playermovement = false;

        isTalking = true;
        dialogueUI.SetActive(true);
        npcName.text = Tutorial.name;
        npcDialogueBox.text = Tutorial.dialogue[0];
    }

    void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);

        playerScript.playermovement = true;
    }

    void LookAtPlayer()
    {
        transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
    }

    void Update()
    {
        Debug.Log(currentWaypointIndex);
        Debug.Log(isTalking);

        if(Vector3.Distance(transform.position, destroyBossHere.position) < 1f)
        {
            Debug.Log("die");
            Destroy(gameObject);
        }
    }
}