using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;


namespace CollectionSystem
{
    //list of items to check for
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

        //items collected
        public void ItemCollected()
        {
            NumberOfItemsCollected++;

            OnItemsCollectedForBlue.Invoke(this);
            Debug.Log("Number of items collected is " + NumberOfItemsCollected);
        }
        //items collected for orange
        public void ItemCollectedForOrange()
        {
            NumberOfItemsForOrangeCollected++;

            OnItemsCollectedForOrange.Invoke(this);
        }

        //number of cars fixed
        public void NumberOfCarsFixed()
        {
            NumOfCarFixed++;
            Debug.Log("Car Number " + NumOfCarFixed + " Is Fixed");
        }
        //generate random number of items to be collected
        public void RandomCollectNum()
        {
            RandomCollect = Random.Range(5, 11);
            Debug.Log("Random Number To Be Collected :  " + RandomCollect);

        }
    }
}
