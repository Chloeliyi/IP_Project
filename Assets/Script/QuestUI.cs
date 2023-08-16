using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CollectionSystem
{
    public class QuestUI : MonoBehaviour
    {
        private TextMeshProUGUI QuestNumberLabel;

        void Start()
        {
            QuestNumberLabel = GetComponent<TextMeshProUGUI>();

        }
        public void UpdateQuestNum(QuestController QuestController)
        {

            QuestNumberLabel.text = "Quest: " + QuestController.QuestCounter.ToString();

        }
    }
}
