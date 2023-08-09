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
        public bool hasCar = false;

        public int NumberOfItemsCollected;
        public int RandomCollect;

        //public TextMeshProUGUI ItemsCollectedLabel;
        //public TextMeshProUGUI ToBeCollectedLabel;

        //[SerializeField] private RandomNumber RandomCollectNum;
        //public UnityEvent<Inventory> OnItemsCollected;

        private void Awake()
        {
            //ToBeCollectedLabel = GetComponent<TextMeshProUGUI>();
            //ItemsCollectedLabel = GetComponent<TextMeshProUGUI>();
            RandomCollectNum();

            instance = this;
        }

        public void UpdateItemsCount()
        {
            NumberOfItemsCollected++;

            //ItemsCollectedLabel.text = NumberOfItemsCollected.ToString();
            Debug.Log("Number of items collected is " + NumberOfItemsCollected);
        }

        public void RandomCollectNum()
        {
            RandomCollect = Random.Range(1, 6);
            //ToBeCollectedLabel.text = "/" + RandomCollect.ToString();
            Debug.Log("Random Number To Be Collected :  " + RandomCollect);
        }
    }
}
