using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace CollectionSystem
{
    public class InventoryUI : MonoBehaviour
    {

        //public TextMeshProUGUI ItemsCollectedLabel;
        public TextMeshProUGUI ToBeCollectedLabel;

        [SerializeField] private Inventory _keyInventory;

        void Start()
        {
            //ItemsCollectedLabel = GetComponent<TextMeshProUGUI>();
        }
        void Update()
        {
            //UpdateItemLabel();
        }
        public void UpdateItemLabel()
        {
            //ItemsCollectedLabel.text = Inventory.NumberOfItemsCollected.ToString();
            //Debug.Log("Label of items collected is " + ItemsCollectedLabel.text);
        }
    }
}
