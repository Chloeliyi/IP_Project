using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CollectionSystem
{
    public class Inventory : MonoBehaviour
    {
        public bool hasItemOne = false;
        public bool hasItemTwo = false;
        public bool hasCar = false;

        public void Message()
        {
            Debug.Log("This is inventory");
        }
    }
}
