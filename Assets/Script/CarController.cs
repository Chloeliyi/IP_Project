using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CollectionSystem
{
    public class CarController : MonoBehaviour
    {

        [SerializeField] private GameObject Player;

        [SerializeField] private GameObject CarModel;

        [SerializeField] private Camera PlayerCamera;

        [SerializeField] private Camera CarCamera;

        [SerializeField] private Image Crosshair = null;

        [SerializeField] private Inventory _keyInventory;

        [SerializeField] private WheelController _Car;

        //private TestSlider FixSlider;

        [SerializeField] private GameObject _fixSlider;

        [SerializeField] private GameObject ItemsLabel;

        public TextMeshProUGUI ToBeCollectedLabel;

        public float RandomColNum = 0;

        private CarControllerAI Carfixed;

        private ItemController _ItemController;

        public bool PlayPauseSpark = false;
        //public bool PlayPauseSmoke = false;

        void Start()
        {

            ItemsLabel.SetActive(false);
            PlayPauseSpark = false;
            //PlayPauseSmoke = false;
    }
        void Awake()
        {
            Carfixed = GetComponent<CarControllerAI>();
            _ItemController = GetComponent<ItemController>();
        }
        public void CheckForCarParts()
        {
            if (_keyInventory.hasCar == false)
            {
                if (RandomColNum < 1)
                {
                    _keyInventory.RandomCollectNum();
                    ToBeCollectedLabel.text = "/" + _keyInventory.RandomCollect.ToString();
                    RandomColNum++;
                    ItemsLabel.SetActive(true);
                }

                //ItemsLabel.SetActive(true);

                if (_keyInventory.NumberOfItemsCollected == _keyInventory.RandomCollect)
                {
                    Debug.Log("Car can be fixed");
                    Debug.Log(_keyInventory.NumberOfItemsCollected);
                    Debug.Log(_keyInventory.RandomCollect);

                    ItemsLabel.SetActive(false);
                    _fixSlider.SetActive(true);

                    _keyInventory.NumberOfItemsCollected -= _keyInventory.RandomCollect;

                    Debug.Log(_keyInventory.NumberOfItemsCollected);

                    //RandomColNum = 0;
                    //GetComponent<CarControllerAI>().enabled = true;
                    //GetComponent<ItemController>().enabled = false;
                    //GetComponent<CarController>().enabled = false;
                    //Carfixed.CarIsRepaired();

                }
                else if (_keyInventory.NumberOfItemsCollected <= _keyInventory.RandomCollect)
                {
                    Debug.Log("Get more objects to fix car");
                    Debug.Log(_keyInventory.NumberOfItemsCollected);
                    Debug.Log(_keyInventory.RandomCollect);
                }
                else if (_keyInventory.NumberOfItemsCollected >= _keyInventory.RandomCollect)
                {
                    Debug.Log("More than needed parts");
                    Debug.Log(_keyInventory.NumberOfItemsCollected);
                    Debug.Log(_keyInventory.NumberOfItemsCollected);

                    ItemsLabel.SetActive(false);
                    _fixSlider.SetActive(true);

                    _keyInventory.NumberOfItemsCollected -= _keyInventory.RandomCollect;

                    //RandomColNum = 0;

                    //GetComponent<CarControllerAI>().enabled = true;
                    //GetComponent<ItemController>().enabled = false;
                    //GetComponent<CarController>().enabled = false;
                    //Carfixed.CarIsRepaired();
                }
            }
            else if (_keyInventory.hasCar == true)
            {
                GetInVehicle();
            }
        }

        void Update()
        {
            //Get Off Car
            if (_keyInventory.hasCar == true || _keyInventory.hasTowTruck == true)
            {
                if (Input.GetKeyDown(KeyCode.Backspace))
                {
                    Debug.Log("Backspace is pressed");
                    GetComponent<WheelController>().enabled = false;
                    Player.transform.parent = null;
                    CarCamera.gameObject.SetActive(false);
                    Player.SetActive(true);
                    Crosshair.gameObject.SetActive(true);
                }
                else
                {
                    Debug.Log("Backspace is not pressed");
                }
            }
        }

        public void GetInVehicle()
        {
            Debug.Log("In Car");

            Player.SetActive(false);
            ItemsLabel.SetActive(false);
            Crosshair.gameObject.SetActive(false);
            CarCamera.gameObject.SetActive(true);
            GetComponent<WheelController>().enabled = true;

            Player.transform.parent = CarModel.transform;
            Player.transform.Rotate(0.0f, 270.0f, 0.0f, Space.Self);

            //PlayPauseSmoke = true;
        }
    }
}
