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
        public bool hasBlueCar = false;
        public bool hasOrangeCar = false;
        public bool hasTowTruck = false;
        public bool hasTesla = false;
        public bool IsSlider = false;

        public int NumberOfItemsCollected { get; set; }
        public int NumberOfItemsForOrangeCollected { get; set; }

        public int RandomCollect;
        public int NumOfCarFixed;

        public UnityEvent<Inventory> OnItemsCollectedForBlue;
        public UnityEvent<Inventory> OnItemsCollectedForOrange;

        private void Awake()
        {
            instance = this;
        }

        public void ItemCollected()
        {
            NumberOfItemsCollected++;

            OnItemsCollectedForBlue.Invoke(this);
            Debug.Log("Number of items collected is " + NumberOfItemsCollected);
        }
        public void ItemCollectedForOrange()
        {
            NumberOfItemsForOrangeCollected++;

            OnItemsCollectedForOrange.Invoke(this);
        }

        public void NumberOfCarsFixed()
        {
            NumOfCarFixed++;
            Debug.Log("Car Number " + NumOfCarFixed + " Is Fixed");
        }
        public void RandomCollectNum()
        {
            RandomCollect = Random.Range(5, 11);
            Debug.Log("Random Number To Be Collected :  " + RandomCollect);

        }
    }
}
