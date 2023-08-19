using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Jae Ng
[CreateAssetMenu(fileName = "NPC file", menuName = "NPC Files Archive")]
//Create asset menus for NPCs and text file for name, dialogue and player dialogue
public class NPC : ScriptableObject
{
    public string name;
    [TextArea(3,15)]
    public string[] dialogue;
    [TextArea(3,15)]
    public string[] playerDialogue;
}
