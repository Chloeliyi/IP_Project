using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;


namespace CollectionSystem
{
    public class Inventory : MonoBehaviour
    {
        public static Inventory instance;
        public bool hasItemOne = false;
        public bool hasItemTwo = false;
        public bool hasItemThree = false;
        public bool hasItemFour = false;
        public bool hasCar = false;
        public bool hasTowTruck = false;
        public bool IsSlider = false;

        public int NumberOfItemsCollected { get; set; }
        public int RandomCollect;

        public int NumOfCarFixed;

        //private InventoryUI ItemUI;

        //public TextMeshProUGUI ItemsCollectedLabel;

        public UnityEvent<Inventory> OnItemsCollected;

        private void Awake()
        {
            //ItemsCollectedLabel = GetComponent<TextMeshProUGUI>();

            instance = this;
        }

        public void ItemCollected()
        {
            NumberOfItemsCollected++;

            OnItemsCollected.Invoke(this);
            Debug.Log("Number of items collected is " + NumberOfItemsCollected);
            //ItemsCollectedLabel.text = NumberOfItemsCollected.ToString();
        }

        public void NumberOfCarsFixed()
        {
            NumOfCarFixed++;
        }
        public void RandomCollectNum()
        {
            RandomCollect = Random.Range(5, 11);
            Debug.Log("Random Number To Be Collected :  " + RandomCollect);

        }
    }
}
