using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CollectionSystem
{
    public class ItemController : MonoBehaviour
    {

        [SerializeField] private bool ItemOne = false;
        [SerializeField] private bool ItemTwo = false;

        [SerializeField] private RandomSpawner _Spawner = null;

        [SerializeField] private Inventory _keyInventory = null;

        void Awake()
        {
            _Spawner = GetComponent<RandomSpawner>();

            Debug.Log(_Spawner);
            Debug.Log(_keyInventory);
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
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
