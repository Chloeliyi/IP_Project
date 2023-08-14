using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CollectionSystem
{
    public class RandomSpawner : MonoBehaviour
    {
        public GameObject ItemOne;
        public GameObject ItemTwo;
        public GameObject ItemThree;
        public GameObject ItemFour;

        int ItemsAtSpawn = 2;

        private void Start()
        {
            SpawnItemOneAtStart();
            SpawnItemTwoAtStart();
            SpawnItemThreeAtStart();
            SpawnItemFourAtStart();
        }

        public void SpawnItemOneAtStart()
        {

            for (var i = 0; i <= ItemsAtSpawn; i++)
            {
                //Vector3 SpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));
                Vector3 SpawnPosition = new Vector3(Random.Range(3, 23), 1, Random.Range(34,54));

                Instantiate(ItemOne, SpawnPosition, Quaternion.identity);

                Debug.Log("Number Of Item Ones is " + i);
            }
        }

        public void SpawnItemOne()
        {
            //Vector3 SpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));
            Vector3 SpawnPosition = new Vector3(Random.Range(3, 23), 1, Random.Range(34, 54));

            Instantiate(ItemOne, SpawnPosition, Quaternion.identity);
        }

        public void SpawnItemTwoAtStart()
        {

            for (var i = 0; i <= ItemsAtSpawn; i++)
            {
                //Vector3 SpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));
                Vector3 SpawnPosition = new Vector3(Random.Range(3, 23), 1, Random.Range(34, 54));

                Instantiate(ItemTwo, SpawnPosition, Quaternion.identity);

                Debug.Log("Number Of Item Twos is " + i);
            }
        }

        public void SpawnItemTwo()
        {
            //Vector3 SpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));
            Vector3 SpawnPosition = new Vector3(Random.Range(3, 23), 1, Random.Range(34, 54));

            Instantiate(ItemTwo, SpawnPosition, Quaternion.identity);
        }

        public void SpawnItemThreeAtStart()
        {

            for (var i = 0; i <= ItemsAtSpawn; i++)
            {
                //Vector3 SpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));
                Vector3 SpawnPosition = new Vector3(Random.Range(3, 23), 1, Random.Range(34, 54));

                Instantiate(ItemThree, SpawnPosition, Quaternion.identity);
            }
        }

        public void SpawnItemThree()
        {
            //Vector3 SpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));
            Vector3 SpawnPosition = new Vector3(Random.Range(3, 23), 1, Random.Range(34, 54));

            Instantiate(ItemThree, SpawnPosition, Quaternion.identity);
        }

        public void SpawnItemFourAtStart()
        {

            for (var i = 0; i <= ItemsAtSpawn; i++)
            {
                //Vector3 SpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));
                Vector3 SpawnPosition = new Vector3(Random.Range(3, 23), 1, Random.Range(34, 54));

                Instantiate(ItemFour, SpawnPosition, Quaternion.identity);
            }
        }
        
         public void SpawnItemFour()
        {
            //Vector3 SpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));
            Vector3 SpawnPosition = new Vector3(Random.Range(3, 23), 1, Random.Range(34, 54));

            Instantiate(ItemFour, SpawnPosition, Quaternion.identity);
        }
    }
}
