using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CollectionSystem
{
    public class ItemController : MonoBehaviour
    {

        [SerializeField] private bool ItemOne = false;
        [SerializeField] private bool ItemTwo = false;
        [SerializeField] private bool Car = false;

        [SerializeField] private GameObject Player;

        [SerializeField] private Camera PlayerCamera;

        [SerializeField] private Camera CarCamera;

        [SerializeField] private RandomSpawner _Spawner = null;

        [SerializeField] private Inventory _keyInventory = null;

        [SerializeField] private WheelController _Car = null;

        void Awake()
        {
            _Spawner = GetComponent<RandomSpawner>();

            Debug.Log(_Spawner);
            Debug.Log(_keyInventory);
            Debug.Log(_Car);
        }
        public void ObjectInteraction()
        {
            if(ItemOne)
            {
                _keyInventory.hasItemOne = true;
                Debug.Log(gameObject.name);
                Destroy(gameObject);

                _keyInventory.Message();

                _Spawner.Message();
                //Debug.Log("Number Of Item Ones is " + Spawner.NumberOfItems);

                //Spawner.NumberOfItems -= 1;

                //Spawner.SpawnItemOne();
            }
            else if (ItemTwo)
            {
                _keyInventory.hasItemTwo = true;
                Debug.Log(gameObject.name);
                gameObject.SetActive(false);

                //Spawner.SpawnItemTwo();
            }
            else if (Car)
            {
                _keyInventory.hasCar = true;
                Player.SetActive(false);
                _Car.CarMovement();

                if (Input.GetKey(KeyCode.Z))
                {
                    Debug.Log("Back To Player");
                    _keyInventory.hasCar = false;
                    CarCamera.gameObject.SetActive(false);
                    Player.SetActive(true);
                }
                else
                {
                    Debug.Log("Z is not pressed");
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            /*if (Input.GetKey(KeyCode.Z))
            {
                Debug.Log("Z");
            }*/
        }
    }
}
