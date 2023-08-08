using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace CollectionSystem
{
    public class InventoryUI : MonoBehaviour
    {

        public TextMeshProUGUI ItemsCollectedLabel;

        [SerializeField] private Inventory Inventory;
         
        void Start()
        {
            ItemsCollectedLabel = GetComponent<TextMeshProUGUI>();

            //UpdateItemLabel();
        }

        public void UpdateItemLabel()
        {
            ItemsCollectedLabel.text = Inventory.NumberOfItemsCollected.ToString();
            Debug.Log("Label of items collected is " + ItemsCollectedLabel.text);
        }
    }
}
