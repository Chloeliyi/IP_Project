using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CollectionSystem
{
    public class PartsController : MonoBehaviour
    {
        [SerializeField] private Inventory _keyInventory;
        [SerializeField] private RandomSpawner _Spawner;

        //[SerializeField] private int NumberOfItemsCollected = 0;

        [SerializeField] private int WaitTime = 1;

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("Number Of Items Collected At Start : " + _keyInventory.NumberOfItemsCollected);

            //_Spawner = GetComponent<RandomSpawner>();
        }

        public void ItemsCollected()
        {
            if (_keyInventory.hasItemOne)
            {
                _keyInventory.UpdateItemsCount();

                Debug.Log("Number Of Items Collected : " + _keyInventory.NumberOfItemsCollected);
                StartCoroutine(TurnItemOneOnAndOff());
            }
            /*else if (_keyInventory.hasItemTwo)
            {
                _keyInventory.UpdateItemsCount();

                Debug.Log("Number Of Items Collected : " + _keyInventory.NumberOfItemsCollected);
                StartCoroutine(TurnItemTwoOnAndOff());
            }*/
        }
        public void ItemTwoCollected()
        {
            if (_keyInventory.hasItemTwo)
            {
                _keyInventory.UpdateItemsCount();

                Debug.Log("Number Of Items Collected : " + _keyInventory.NumberOfItemsCollected);
                StartCoroutine(TurnItemTwoOnAndOff());
            }
        }

        IEnumerator TurnItemOneOnAndOff()
        {
            Debug.Log("Coroutine Start");
            Debug.Log("Has Item One Is " + _keyInventory.hasItemOne);
            Debug.Log(gameObject.name);

            yield return new WaitForSeconds(WaitTime);

            _keyInventory.hasItemOne = false;
            gameObject.SetActive(false);

            Debug.Log("Coroutine ended");
            Debug.Log("Has Item One Is " + _keyInventory.hasItemOne);

            _Spawner.SpawnItemOne();
        }
        IEnumerator TurnItemTwoOnAndOff()
        {
            Debug.Log("Coroutine Start");
            Debug.Log("Has Item Two Is " + _keyInventory.hasItemTwo);
            Debug.Log(gameObject.name);

            yield return new WaitForSeconds(WaitTime);

            _keyInventory.hasItemTwo = false;
            gameObject.SetActive(false);

            Debug.Log("Coroutine ended");
            Debug.Log("Has Item Two Is " + _keyInventory.hasItemTwo);

            _Spawner.SpawnItemTwo();
        }
    }
}
