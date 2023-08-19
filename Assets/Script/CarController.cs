using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//Chloe Chan
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

        [SerializeField] private GameObject _fixSlider;

        [SerializeField] private GameObject ItemsLabel;

        public TextMeshProUGUI ToBeCollectedLabel;

        public float RandomColNum = 0;


        public bool PlayPauseSpark = false;

        void Start()
        {

            ItemsLabel.SetActive(false);
            PlayPauseSpark = false;
    }
        void Awake()
        {
        }

        //Check For Car Parts
        public void CheckForCarParts()
        {
            if (_keyInventory.hasBlueCar == true)
            {
                //Generate random number of parts to be collected
                if (RandomColNum < 1)
                {
                    _keyInventory.RandomCollectNum();
                    ToBeCollectedLabel.text = "/" + _keyInventory.RandomCollect.ToString();
                    RandomColNum++;
                    ItemsLabel.SetActive(true);
                }

                //Check if number of parts collected is correct
                if (_keyInventory.NumberOfItemsCollected == _keyInventory.RandomCollect)
                {
                    Debug.Log("Blue Car can be fixed");
                    Debug.Log(_keyInventory.NumberOfItemsCollected);
                    Debug.Log(_keyInventory.RandomCollect);

                    ItemsLabel.SetActive(false);
                    _fixSlider.SetActive(true);

                    _keyInventory.NumberOfItemsCollected -= _keyInventory.RandomCollect;
                    _keyInventory.hasBlueCar = false;
                    _keyInventory.NumberOfItemsForOrangeCollected = 0;

                    /*RandomColNum = 0;
                    Carfixed.CarFixed = true;
                    Carfixed.Fixing();
                    _keyInventory.NumberOfCarsFixed();*/

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
                   //_fixSlider.SetActive(true);

                    _keyInventory.NumberOfItemsCollected -= _keyInventory.RandomCollect;
                    _keyInventory.hasBlueCar = false;
                    _keyInventory.NumberOfItemsForOrangeCollected = _keyInventory.NumberOfItemsCollected;

                    /*RandomColNum = 0;
                    Carfixed.CarFixed = true;
                    Carfixed.Fixing();
                    _keyInventory.NumberOfCarsFixed();*/

                }
            }

            if (_keyInventory.hasOrangeCar == true)
            {
                //Generate random number of parts to be collected
                if (RandomColNum < 1)
                {
                    _keyInventory.RandomCollectNum();
                    ToBeCollectedLabel.text = "/" + _keyInventory.RandomCollect.ToString();
                    RandomColNum++;
                    ItemsLabel.SetActive(true);
                }

                //Check if number of parts collected is correct
                if (_keyInventory.NumberOfItemsForOrangeCollected == _keyInventory.RandomCollect)
                {
                    Debug.Log("Orange Car can be fixed");
                    Debug.Log(_keyInventory.NumberOfItemsForOrangeCollected);
                    Debug.Log(_keyInventory.RandomCollect);

                    ItemsLabel.SetActive(false);
                    _fixSlider.SetActive(true);

                    _keyInventory.NumberOfItemsForOrangeCollected -= _keyInventory.RandomCollect;
                    _keyInventory.hasOrangeCar = false;
                    _keyInventory.NumberOfItemsCollected = 0;


                }
                else if (_keyInventory.NumberOfItemsForOrangeCollected <= _keyInventory.RandomCollect)
                {
                    Debug.Log("Get more objects to fix car");
                    Debug.Log(_keyInventory.NumberOfItemsForOrangeCollected);
                    Debug.Log(_keyInventory.RandomCollect);
                }
                else if (_keyInventory.NumberOfItemsForOrangeCollected >= _keyInventory.RandomCollect)
                {
                    Debug.Log("More than needed parts");
                    Debug.Log(_keyInventory.NumberOfItemsForOrangeCollected);

                    ItemsLabel.SetActive(false);
                    _fixSlider.SetActive(true);

                    _keyInventory.NumberOfItemsForOrangeCollected -= _keyInventory.RandomCollect;
                    _keyInventory.hasOrangeCar = false;
                    _keyInventory.NumberOfItemsCollected = _keyInventory.NumberOfItemsForOrangeCollected;

                }
            }
            /*else if (_keyInventory.hasBlueCar == true)
            {
                GetInVehicle();
            }*/
        }

        void Update()
        {
            //Get Off Car
            if ( _keyInventory.hasTowTruck == true || _keyInventory.hasTesla == true)
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

        //Get In Car
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
        }
    }
}
