using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace CollectionSystem
{
    public class QuestController : MonoBehaviour
    {
        public static QuestController instance;

        [SerializeField] private TextMeshProUGUI QuestDetails;
        public int QuestCounter { get; set; }

        //[SerializeField] private bool QuestComplete = false;

        public UnityEvent<QuestController> OnQuestUpdate;

        private void Awake()
        {
            QuestCounter = 1;
            instance = this;
        }

        void Update()
        {
            //UpdateQuestDetails();
        }

        public void QuestCounted()
        {
            QuestCounter++;

            OnQuestUpdate.Invoke(this);

            UpdateQuestDetails();
        }

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
                QuestDetails.text = "Fix Three Cars";
            }
        }
    }
}
