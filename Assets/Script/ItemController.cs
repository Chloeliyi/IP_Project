using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//Chloe Chan
namespace CollectionSystem
{
    public class ItemController : MonoBehaviour
    {
        //Check for items
        [SerializeField] private bool ItemOne = false;
        [SerializeField] private bool ItemTwo = false;
        [SerializeField] private bool ItemThree = false;
        [SerializeField] private bool ItemFour = false;
        [SerializeField] private bool BlueCar = false;
        [SerializeField] private bool OrangeCar = false;
        [SerializeField] private bool TowTruck = false;
        [SerializeField] private bool Tesla = false;
        [SerializeField] private bool FixSlider = false;

        [SerializeField] private bool TaskOne = false;
        [SerializeField] private bool TaskTwo = false;
        [SerializeField] private Image Crosshair = null;

        private int Duration;

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
            else if (BlueCar)
            {
                CheckVehicle = GetComponent<CarController>();
            }
            else if (OrangeCar)
            {
                CheckVehicle = GetComponent<CarController>();
            }
            else if (TowTruck)
            {
                CheckVehicle = GetComponent<CarController>();
            }
            else if (Tesla)
            {
                CheckVehicle = GetComponent<CarController>();
            }
            else if (FixSlider)
            {
                CheckSlider = GetComponent<TestSlider>();
            }
        }
        //Raycast object interaction
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
            if (BlueCar)
            {
                _keyInventory.hasBlueCar = true;
                CheckVehicle.CheckForCarParts();

            }
            if (OrangeCar)
            {
                _keyInventory.hasOrangeCar = true;
                CheckVehicle.CheckForCarParts();

            }
            if (TowTruck)
            {
                _keyInventory.hasTowTruck = true;
                CheckVehicle.GetInVehicle();
            }
            if (Tesla)
            {
                _keyInventory.hasTesla = true;
                CheckVehicle.GetInVehicle();
            }
            if (FixSlider)
            {
                _keyInventory.IsSlider = true;
                GetComponent<TestSlider>().enabled = true;
            }
            if(TaskOne)
            {
                Destroy(gameObject);
            }
            if(TaskTwo)
            {
                Destroy(gameObject);
            }
        }
        private void Update()
        {
        }
    }
}
