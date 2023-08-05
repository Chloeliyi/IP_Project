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

        public TMP_Text ItemsCollected;

        [SerializeField] private int NumberOfItemsCollected = 0;

        [SerializeField] private RandomSpawner _Spawner = null;

        [SerializeField] private Inventory _keyInventory = null;

        [SerializeField] private WheelController _Car = null;

        void Awake()
        {

            CarCamera.gameObject.SetActive(false);
            GetComponent<WheelController>().enabled = false;

            ItemsCollected.text = NumberOfItemsCollected.ToString();
        }
        public void ObjectInteraction()
        {
            if(ItemOne)
            {
                _keyInventory.hasItemOne = true;
                //Debug.Log("Number Of Item Ones is " + _Spawner.NumberOfItemOne);
                Debug.Log("Has Item One Is " + _keyInventory.hasItemOne);
                Debug.Log(gameObject.name);
                Destroy(gameObject);

                NumberOfItemsCollected++;

                Debug.Log("Number of items collected is " + NumberOfItemsCollected);

                StartCoroutine(TurnOff());
                _keyInventory.hasItemOne = false;
                Debug.Log("Coroutine ended");
                Debug.Log("Has Item One Is " + _keyInventory.hasItemOne);

                //_Spawner.SpawnItemOne();

            }
            else if (ItemTwo)
            {
                _keyInventory.hasItemTwo = true;
                Debug.Log(gameObject.name);
                Destroy(gameObject);

                _Spawner.SpawnItemTwo();
            }
            else if (Car)
            {
                _keyInventory.hasCar = true;
                Player.SetActive(false);

                Crosshair.gameObject.SetActive(false);
                CarCamera.gameObject.SetActive(true);
                GetComponent<WheelController>().enabled = true;

                Player.transform.parent = CarModel.transform;
                Player.transform.Rotate(0.0f, 270.0f, 0.0f, Space.Self);
            }
        }
         
        IEnumerator TurnOff()
        {
            yield return new WaitForSeconds(1.0f);
        }

        public void Update()
        {
            ItemsCollected.text = NumberOfItemsCollected.ToString();
            Debug.Log(ItemsCollected.text);

            BackToPlayer();
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
