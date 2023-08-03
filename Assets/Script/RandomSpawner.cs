using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CollectionSystem
{
    public class RandomSpawner : MonoBehaviour
    {
        public GameObject ItemOne;
        public GameObject ItemTwo;
        int ItemsAtSpawn = 2;

        private void Start()
        {
            SpawnItemOne();
            SpawnItemTwo();
        }

        public void Message()
        {
            Debug.Log("This is Random Spawner");
        }

        public void SpawnItemOne()
        {

            /*int SpawnPointX = Random.Range(0, 11);
            int SpawnPointZ = Random.Range(0, 11);
            int SpawnPointY = Random.Range(0, 11);

            Vector3 SpawnPosition = new Vector3(SpawnPointX, SpawnPointY, SpawnPointZ);*/

            for (var NumberOfItems = 0; NumberOfItems <= ItemsAtSpawn; NumberOfItems++)
            {
                Vector3 SpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));

                Instantiate(ItemOne, SpawnPosition, Quaternion.identity);

                Debug.Log("Number Of Item Ones is " + NumberOfItems);
            }
        }

        public void SpawnItemTwo()
        {

            for (var i = 0; i <= ItemsAtSpawn; i++)
            {
                Vector3 SpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));

                Instantiate(ItemTwo, SpawnPosition, Quaternion.identity);

                Debug.Log(i);
            }
        }
    }
}
