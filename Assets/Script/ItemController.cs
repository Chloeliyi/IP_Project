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

        [SerializeField] private GameObject Player;

        [SerializeField] private GameObject CarModel;

        [SerializeField] private Camera PlayerCamera;

        [SerializeField] private Camera CarCamera;

        [SerializeField] private Image Crosshair = null;

        [SerializeField] private RandomSpawner _Spawner = null;

        [SerializeField] private Inventory _keyInventory = null;

        [SerializeField] private WheelController _Car = null;

        [SerializeField] private RandomNumber RandomCollectNum = null;

        [SerializeField] private InventoryUI ItemsCollected = null;

        [SerializeField] private int WaitTime = 1;


        void Start()
        {
            //RandomCollectNum.RandomCollectNum();
        }
        public void ObjectInteraction()
        {
            if(ItemOne)
            {
                StartCoroutine(TurnOnAndOff());

                _Spawner.SpawnItemOne();

                /*_keyInventory.hasItemOne = true;
                Debug.Log("Has Item One Is " + _keyInventory.hasItemOne);
                Debug.Log(gameObject.name);
                Destroy(gameObject);

                //NumberOfItemsCollected += 1;
                //Debug.Log("Number of items collected is " + NumberOfItemsCollected);

                StartCoroutine(TurnOff());

                _Spawner.SpawnItemOne();*/

            }
            else if (ItemTwo)
            {
                _keyInventory.hasItemTwo = true;
                Debug.Log("Has Item Two Is " + _keyInventory.hasItemTwo);
                Debug.Log(gameObject.name);
                gameObject.SetActive(false);
                _keyInventory.hasItemTwo = false;
                Debug.Log("Coroutine ended");
                Debug.Log("Has Item Two Is " + _keyInventory.hasItemTwo);


                _Spawner.SpawnItemTwo();
            }
            else if (Car)
            {
                //CheckForCarParts();
                StartCoroutine(TurnCarOnAndOff());

                /*_keyInventory.hasCar = true;
                Player.SetActive(false);

                Crosshair.gameObject.SetActive(false);
                CarCamera.gameObject.SetActive(true);
                GetComponent<WheelController>().enabled = true;

                Player.transform.parent = CarModel.transform;
                Player.transform.Rotate(0.0f, 270.0f, 0.0f, Space.Self);*/
            }
        }

        public void CheckForCarParts()
        {
            if (_keyInventory.NumberOfItemsCollected == RandomCollectNum.RandomCollect)
            {
                Debug.Log("Car can be fixed");
                Debug.Log(_keyInventory.NumberOfItemsCollected);
                Debug.Log(RandomCollectNum.RandomCollect);
            }
            else if (_keyInventory.NumberOfItemsCollected <= RandomCollectNum.RandomCollect)
            {
                Debug.Log("Get more objects to fix car");
                Debug.Log(_keyInventory.NumberOfItemsCollected);
                Debug.Log(RandomCollectNum.RandomCollect);
            }
            else if (_keyInventory.NumberOfItemsCollected >= RandomCollectNum.RandomCollect)
            {
                Debug.Log("More than needed parts");
                Debug.Log(_keyInventory.NumberOfItemsCollected);
                _keyInventory.NumberOfItemsCollected -= RandomCollectNum.RandomCollect;
                Debug.Log(_keyInventory.NumberOfItemsCollected);
            }
        }

        IEnumerator TurnOnAndOff()
        {
            Debug.Log("Coroutine Start");
            Debug.Log("Item One is " + ItemOne);
            _keyInventory.hasItemOne = true;
            Debug.Log("Has Item One Is " + _keyInventory.hasItemOne);
            Debug.Log(gameObject.name);
            _keyInventory.ItemsCollected();

            yield return new WaitForSeconds(WaitTime);
            _keyInventory.hasItemOne = false;

            gameObject.SetActive(false);

            Debug.Log("Item One is " + ItemOne);
            Debug.Log("Coroutine ended");
            Debug.Log("Has Item One Is " + _keyInventory.hasItemOne);
        }

        IEnumerator TurnCarOnAndOff()
        {
            Debug.Log("Coroutine Start");
            _keyInventory.hasCar = true;
            Debug.Log("Has Car is " + _keyInventory.hasCar);
            Debug.Log(_keyInventory.NumberOfItemsCollected);
            Debug.Log(RandomCollectNum.RandomCollect);

            //Car = false;
            Debug.Log("Car is " + Car);
            yield return new WaitForSeconds(WaitTime);

            _keyInventory.hasCar = false;
            //Car = true;
            Debug.Log("Has Car is " + _keyInventory.hasCar);

            Debug.Log("Coroutine ended");
        }

        public void Update()
        {
            ItemsCollected.UpdateItemLabel();
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
