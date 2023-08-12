using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CollectionSystem
{
    public class ItemController : MonoBehaviour
    {

        [SerializeField] private bool ItemOne = false;
        [SerializeField] private bool ItemTwo = false;
        [SerializeField] private bool Car = false;
        [SerializeField] private bool FixSlider = false;

        /*[SerializeField] private GameObject Player;

        [SerializeField] private GameObject CarModel;

        [SerializeField] private Camera PlayerCamera;

        [SerializeField] private Camera CarCamera;*/

        [SerializeField] private Image Crosshair = null;

        [SerializeField] private Inventory _keyInventory;

        //[SerializeField] private RandomNumber RandomCollectNum;

        private PartsController CheckParts;

        private CarController CheckCar;

        private TestSlider CheckSlider;
        private void Start()
        {
            if (ItemOne)
            {
                CheckParts = GetComponent<PartsController>();
            }
            else if (ItemTwo)
            {
                CheckParts = GetComponent<PartsController>();
            }
            else if (Car)
            {
                CheckCar = GetComponent<CarController>();
            }
            else if (FixSlider)
            {
                CheckSlider = GetComponent<TestSlider>();
            }
        }
        public void ObjectInteraction()
        {
            if (ItemOne)
            {
                _keyInventory.hasItemOne = true;
                CheckParts.ItemsCollected();

                Debug.Log("Number Of Items Collected : " + _keyInventory.NumberOfItemsCollected);
            }
            if (ItemTwo)
            {
                _keyInventory.hasItemTwo = true;
                CheckParts.ItemsCollected();

                Debug.Log("Number Of Items Collected : " + _keyInventory.NumberOfItemsCollected);
            }
            if (Car)
            {
                //_keyInventory.hasCar = true;
                CheckCar.CheckForCarParts();

            }
            if (FixSlider)
            {
                _keyInventory.IsSlider = true;
                GetComponent<TestSlider>().enabled = true;
            }
        }
        private void Update()
        {
        }
    }
}
