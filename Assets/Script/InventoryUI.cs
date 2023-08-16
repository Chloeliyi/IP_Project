using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace CollectionSystem
{
    public class InventoryUI : MonoBehaviour
    {

        private TextMeshProUGUI ItemsCollectedLabel;
        //public TextMeshProUGUI PartsLabel;

        void Start()
        {
            ItemsCollectedLabel = GetComponent<TextMeshProUGUI>();
          //PartsLabel = GetComponent<TextMeshProUGUI>();
        }

        public void UpdateItemLabel(Inventory Inventory)
        {
            ItemsCollectedLabel.text = Inventory.NumberOfItemsCollected.ToString();
          //PartsLabel.text = "Parts: " + Inventory.NumberOfItemsCollected.ToString();
        }
    }
}
