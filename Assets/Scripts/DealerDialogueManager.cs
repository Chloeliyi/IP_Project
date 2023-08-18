using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class DealerDialogueManager : MonoBehaviour
{
    public PlayerScript playerScript;

    public NPC Dealer;

    bool isTalking = false;

    private float distance;

    public GameObject player;
    public GameObject dialogueUI;

    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public TextMeshProUGUI playerResponse;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
    }

    void OnMouseOver()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if(distance <= 3f)
        {
            //trigger dialogue
            if(Input.GetKeyDown(KeyCode.E) && isTalking == false)
            {
                LookAtPlayer();
                StartConversation();
            }

            //end dialogue
            else if(Input.GetKeyDown(KeyCode.E) && isTalking == true)
            {
                EndDialogue();
            }

            //dealer dialogue
            if(npcDialogueBox.text == Dealer.dialogue[0])
            {
                playerResponse.text = Dealer.playerDialogue[0];
                if(Input.GetKeyDown(KeyCode.Space))
                {   
                    npcDialogueBox.text = Dealer.dialogue[1];
                }
            }

            else if(npcDialogueBox.text == Dealer.dialogue[1])
            {
                playerResponse.text = Dealer.playerDialogue[0];
                if(Input.GetKeyDown(KeyCode.Space))
                {   
                    npcDialogueBox.text = Dealer.dialogue[2];
                    // code to open buy UI
                }
            }

            else if(npcDialogueBox.text == Dealer.dialogue[2] && Input.GetKeyDown(KeyCode.Space))
            {
                EndDialogue();
            }
        }
    }

    void StartConversation()
    {
        playerScript.playermovement = false;

        isTalking = true;
        dialogueUI.SetActive(true);
        npcName.text = Dealer.name;
        npcDialogueBox.text = Dealer.dialogue[0];
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
