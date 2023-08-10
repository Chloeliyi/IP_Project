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

        public GameObject FixCanvas;

        // Start is called before the first frame update
        void Start()
        {
            FixCanvas.SetActive(false);
        }

        public void CheckForCar()
        {
            Debug.Log("Car is clicked");
            Debug.Log("Car has items : " + _keyInventory.NumberOfItemsCollected);
            Debug.Log("Car number of items to be collected : " + _keyInventory.RandomCollect);

            CheckForCarParts();
            //StartCoroutine(TurnCarOnAndOff());

            /*Player.SetActive(false);

            Crosshair.gameObject.SetActive(false);
            CarCamera.gameObject.SetActive(true);
            GetComponent<WheelController>().enabled = true;

            Player.transform.parent = CarModel.transform;
            Player.transform.Rotate(0.0f, 270.0f, 0.0f, Space.Self);*/
        }

        public void CheckForCarParts()
        {
            if (_keyInventory.NumberOfItemsCollected == _keyInventory.RandomCollect)
            {
                Debug.Log("Car can be fixed");
                Debug.Log(_keyInventory.NumberOfItemsCollected);
                Debug.Log(_keyInventory.RandomCollect);

                FixCanvas.SetActive(true);
            }
            else if (_keyInventory.NumberOfItemsCollected <= _keyInventory.RandomCollect)
            {
                Debug.Log("Get more objects to fix car");
                Debug.Log(_keyInventory.NumberOfItemsCollected);
                Debug.Log(_keyInventory.RandomCollect);

                _keyInventory.hasCar = false;
            }
            else if (_keyInventory.NumberOfItemsCollected >= _keyInventory.RandomCollect)
            {
                Debug.Log("More than needed parts");
                Debug.Log(_keyInventory.NumberOfItemsCollected);
                _keyInventory.NumberOfItemsCollected -= _keyInventory.RandomCollect;
                Debug.Log(_keyInventory.NumberOfItemsCollected);
                FixCanvas.SetActive(true);
            }
        }

        IEnumerator TurnCarOnAndOff()
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
        }

        // Update is called once per frame
        void Update()
        {
            //BackToPlayer();
        }

        public void BackToPlayer()
        {
            if (_keyInventory.hasCar == true)
            {

                Debug.Log("Has Car");
                if (Input.GetKeyDown(KeyCode.Backspace))
                {
                    Debug.Log("Backspace is pressed");
                    _keyInventory.hasCar = false;
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
            else
            {
                Debug.Log("Not In Car");
            }
        }
    }
}
