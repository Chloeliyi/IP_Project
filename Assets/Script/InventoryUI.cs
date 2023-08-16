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

        void Start()
        {
            ItemsCollectedLabel = GetComponent<TextMeshProUGUI>();
        }

        public void UpdateItemLabel(Inventory Inventory)
        {
            ItemsCollectedLabel.text = Inventory.NumberOfItemsCollected.ToString();
            //Debug.Log("Label of items collected is " + ItemsCollectedLabel.text);
        }
    }
}
