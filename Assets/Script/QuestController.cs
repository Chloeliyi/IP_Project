using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
//Chloe Chan
namespace CollectionSystem
{
    //Check for quest
    public class QuestController : MonoBehaviour
    {
        public static QuestController instance;

        [SerializeField] private TextMeshProUGUI QuestDetails;
        public int QuestCounter { get; set; }

        [SerializeField] private Inventory _keyInventory;

        public UnityEvent<QuestController> OnQuestUpdate;

        private void Awake()
        {
            QuestCounter = 1;
            instance = this;
        }

        void Update()
        {
        }
        //Update current quest
        public void QuestCounted()
        {
            QuestCounter++;

            OnQuestUpdate.Invoke(this);

            UpdateQuestDetails();
        }
        //Update current quest details
        private void UpdateQuestDetails()
        {
            if (QuestCounter == 1)
            {
                QuestDetails.text = "Go To Garage To Find A Job";
            }
            else if (QuestCounter == 2)
            {
                QuestDetails.text = "Fix Your First Car";
            }
            else if (QuestCounter == 3)
            {
                QuestDetails.text = "Go To The Dealership To Buy Car";
            }
            else if (QuestCounter == 4)
            {
                QuestDetails.text = "Do Your First Race.";
            }
            else if (QuestCounter == 5)
            {
                QuestDetails.text = "Do Your First Race.";
            }
        }
    }
}
