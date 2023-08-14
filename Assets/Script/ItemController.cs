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
        [SerializeField] private bool ItemThree = false;
        [SerializeField] private bool ItemFour = false;
        [SerializeField] private bool Car = false;
        [SerializeField] private bool TowTruck = false;
        [SerializeField] private bool FixSlider = false;

        [SerializeField] private Image Crosshair = null;

        [SerializeField] private Inventory _keyInventory;

        private PartsController CheckParts;

        private CarController CheckVehicle;

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
            else if (ItemThree)
            {
                CheckParts = GetComponent<PartsController>();
            }
            else if (ItemFour)
            {
                CheckParts = GetComponent<PartsController>();
            }
            else if (Car)
            {
                CheckVehicle = GetComponent<CarController>();
            }
            else if (TowTruck)
            {
                CheckVehicle = GetComponent<CarController>();
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
            if (ItemThree)
            {
                _keyInventory.hasItemThree = true;
                CheckParts.ItemsCollected();

                Debug.Log("Number Of Items Collected : " + _keyInventory.NumberOfItemsCollected);
            }
            if (ItemFour)
            {
                _keyInventory.hasItemFour = true;
                CheckParts.ItemsCollected();

                Debug.Log("Number Of Items Collected : " + _keyInventory.NumberOfItemsCollected);
            }
            if (Car)
            {
                CheckVehicle.CheckForCarParts();

            }
            if (TowTruck)
            {
                _keyInventory.hasTowTruck = true;
                CheckVehicle.GetInVehicle();
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
