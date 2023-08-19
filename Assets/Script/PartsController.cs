using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CollectionSystem
{
    public class PartsController : MonoBehaviour
    {
        [SerializeField] private Inventory _keyInventory;
        [SerializeField] private RandomSpawner _Spawner;

        [SerializeField] private int WaitTime = 1;

        void Start()
        {

        }

        //Check for parts collected
        public void ItemsCollected()
        {
            if (_keyInventory.hasItemOne)
            {
                Inventory.instance.ItemCollected();
                Inventory.instance.ItemCollectedForOrange();

                Debug.Log("Number Of Items Collected : " + _keyInventory.NumberOfItemsCollected);
                StartCoroutine(TurnItemOneOnAndOff());
            }
            else if (_keyInventory.hasItemTwo)
            {
                Inventory.instance.ItemCollected();
                Inventory.instance.ItemCollectedForOrange();

                Debug.Log("Number Of Items Collected : " + _keyInventory.NumberOfItemsCollected);
                StartCoroutine(TurnItemTwoOnAndOff());
            }
            else if (_keyInventory.hasItemThree)
            {
                Inventory.instance.ItemCollected();
                Inventory.instance.ItemCollectedForOrange();

                Debug.Log("Number Of Items Collected : " + _keyInventory.NumberOfItemsCollected);
                StartCoroutine(TurnItemThreeOnAndOff());
            }
            else if (_keyInventory.hasItemFour)
            {
                Inventory.instance.ItemCollected();
                Inventory.instance.ItemCollectedForOrange();

                Debug.Log("Number Of Items Collected : " + _keyInventory.NumberOfItemsCollected);
                StartCoroutine(TurnItemFourOnAndOff());
            }
        }

        //Spawn new part after collection
        IEnumerator TurnItemOneOnAndOff()
        {
            Debug.Log("Coroutine Start");
            Debug.Log("Has Item One Is " + _keyInventory.hasItemOne);
            Debug.Log(gameObject.name);

            yield return new WaitForSeconds(WaitTime);

            _keyInventory.hasItemOne = false;
            //gameObject.SetActive(false);
            Destroy(gameObject);

            Debug.Log("Coroutine ended");
            Debug.Log("Has Item One Is " + _keyInventory.hasItemOne);

            _Spawner.SpawnItemOne();
        }
        IEnumerator TurnItemTwoOnAndOff()
        {
            Debug.Log("Coroutine Start");
            Debug.Log("Has Item Two Is " + _keyInventory.hasItemTwo);
            //Debug.Log(gameObject.name);
            Destroy(gameObject);

            yield return new WaitForSeconds(WaitTime);

            _keyInventory.hasItemTwo = false;
            gameObject.SetActive(false);

            Debug.Log("Coroutine ended");
            Debug.Log("Has Item Two Is " + _keyInventory.hasItemTwo);

            _Spawner.SpawnItemTwo();
        }
        IEnumerator TurnItemThreeOnAndOff()
        {
            Debug.Log("Coroutine Start");
            Debug.Log("Has Item Three Is " + _keyInventory.hasItemThree);
            Debug.Log(gameObject.name);

            yield return new WaitForSeconds(WaitTime);

            _keyInventory.hasItemThree = false;
            //gameObject.SetActive(false);
            Destroy(gameObject);

            Debug.Log("Coroutine ended");
            Debug.Log("Has Item Three Is " + _keyInventory.hasItemThree);

            _Spawner.SpawnItemThree();
        }
        IEnumerator TurnItemFourOnAndOff()
        {
            Debug.Log("Coroutine Start");
            Debug.Log("Has Item Four Is " + _keyInventory.hasItemFour);
            Debug.Log(gameObject.name);

            yield return new WaitForSeconds(WaitTime);

            _keyInventory.hasItemFour = false;
            //gameObject.SetActive(false);
            Destroy(gameObject);

            Debug.Log("Coroutine ended");
            Debug.Log("Has Item Four Is " + _keyInventory.hasItemFour);

            _Spawner.SpawnItemFour();
        }
    }
}
