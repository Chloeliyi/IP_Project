using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//Chloe Chan
namespace CollectionSystem
{
    public class InventoryUI : MonoBehaviour
    {
        //public text labels
        public TextMeshProUGUI ItemsCollectedLabel;
        public TextMeshProUGUI ItemsForOrangeCollectedLabel;

        void Start()
        {
            ItemsCollectedLabel = GetComponent<TextMeshProUGUI>();
            ItemsForOrangeCollectedLabel = GetComponent<TextMeshProUGUI>();
        }

        //update label of blue car
        public void UpdateItemLabel(Inventory Inventory)
        {
            ItemsCollectedLabel.text = Inventory.NumberOfItemsCollected.ToString();
        }
        //update label of orange car
        public void UpdateItemForOrangeLabel(Inventory Inventory)
        {
            ItemsForOrangeCollectedLabel.text = Inventory.NumberOfItemsForOrangeCollected.ToString();
        }
    }
}
