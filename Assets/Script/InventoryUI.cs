using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace CollectionSystem
{
    public class InventoryUI : MonoBehaviour
    {

        public TextMeshProUGUI ItemsCollectedLabel;
        private TextMeshProUGUI ItemsForOrangeCollectedLabel;
        //public TextMeshProUGUI PartsLabel;

        void Start()
        {
            ItemsCollectedLabel = GetComponent<TextMeshProUGUI>();
            ItemsForOrangeCollectedLabel = GetComponent<TextMeshProUGUI>();
            //PartsLabel = GetComponent<TextMeshProUGUI>();
        }

        public void UpdateItemLabel(Inventory Inventory)
        {
            ItemsCollectedLabel.text = Inventory.NumberOfItemsCollected.ToString();
          //PartsLabel.text = "Parts: " + Inventory.NumberOfItemsCollected.ToString();
        }

        public void UpdateItemForOrangeLabel(Inventory Inventory)
        {
            ItemsForOrangeCollectedLabel.text = Inventory.NumberOfItemsForOrangeCollected.ToString();
            //PartsLabel.text = "Parts: " + Inventory.NumberOfItemsCollected.ToString();
        }
    }
}
