using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        void Start()
        {
            //FixSlider = GetComponent<TestSlider>();
        }

        /*public void CheckForCar()
        {
            //StartCoroutine(TurnCarOnAndOff());

        Player.SetActive(false);

                Crosshair.gameObject.SetActive(false);
                CarCamera.gameObject.SetActive(true);
                GetComponent<WheelController>().enabled = true;

                Player.transform.parent = CarModel.transform;
                Player.transform.Rotate(0.0f, 270.0f, 0.0f, Space.Self);
                Debug.Log("Has Car");

        }*/

        public void CheckForCarParts()
        {
            if(_keyInventory.hasCar == false)
            {
                if (_keyInventory.NumberOfItemsCollected == _keyInventory.RandomCollect)
                {
                    Debug.Log("Car can be fixed");
                    Debug.Log(_keyInventory.NumberOfItemsCollected);
                    Debug.Log(_keyInventory.RandomCollect);
                    _fixSlider.SetActive(true);
                    //GetComponent<TestSlider>().enabled = true;
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
                    _keyInventory.NumberOfItemsCollected -= _keyInventory.RandomCollect;
                    Debug.Log(_keyInventory.NumberOfItemsCollected);

                    _fixSlider.SetActive(true);
                    //GetComponent<TestSlider>().enabled = true;
                }
            }
            else if (_keyInventory.hasCar == true)
            {
                GetInCar();
            }
        }

        /*IEnumerator TurnCarOnAndOff()
        {
            Debug.Log("Coroutine Start");
            Debug.Log("Car Is clicked");
            Debug.Log("Has Car is " + _keyInventory.hasCar);

            //Car = false;
            yield return new WaitForSeconds(1.0f);

            _keyInventory.hasCar = false;
            //Car = true;
            Debug.Log("Has Car is " + _keyInventory.hasCar);
            Debug.Log("Coroutine ended");
        }*/

        void Update()
        {
            //Get Off Car
            if (_keyInventory.hasCar == true)
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

        public void GetInCar()
        {
            Debug.Log("In Car");

            Player.SetActive(false);

            Crosshair.gameObject.SetActive(false);
            CarCamera.gameObject.SetActive(true);
            GetComponent<WheelController>().enabled = true;

            Player.transform.parent = CarModel.transform;
            Player.transform.Rotate(0.0f, 270.0f, 0.0f, Space.Self);

            /*if (_keyInventory.hasCar == true)
            {
                Debug.Log("In Car");

                Player.SetActive(false);

                Crosshair.gameObject.SetActive(false);
                CarCamera.gameObject.SetActive(true);
                GetComponent<WheelController>().enabled = true;

                Player.transform.parent = CarModel.transform;
                Player.transform.Rotate(0.0f, 270.0f, 0.0f, Space.Self);

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
            }*/
        }
    }
}
