using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace CollectionSystem
{
    public class Inventory : MonoBehaviour
    {
        public bool hasItemOne = false;
        public bool hasItemTwo = false;
        public bool hasCar = false;
        public int NumberOfItemsCollected = 0;

        //public TextMeshProUGUI ToBeCollectedLabel;
        //public int RandomCollect;

        //public UnityEvent<Inventory> OnItemsCollected;

        private void Awake()
        {
            NumberOfItemsCollected = 0;

            Debug.Log("Number Of Items Collected At Start : " + NumberOfItemsCollected);

        }
        public void ItemsCollected()
        {
            NumberOfItemsCollected++;
            Debug.Log("Number of items collected is " + NumberOfItemsCollected);
        }
    }
}
