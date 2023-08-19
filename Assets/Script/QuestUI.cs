using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//Chloe Chan
namespace CollectionSystem
{
    public class QuestUI : MonoBehaviour
    {
        //Update number of quest through unity events
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
