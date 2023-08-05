using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CollectionSystem
{
    public class RandomSpawner : MonoBehaviour
    {
        public GameObject ItemOne;
        public GameObject ItemTwo;
        //public GameObject ItemThree;
        //public GameObject ItemFour;

        int ItemsAtSpawn = 2;
        //public int NumberOfItemOne;

        private void Start()
        {
            SpawnItemOneAtStart();
            //SpawnItemTwoAtStart();
        }

        public void SpawnItemOneAtStart()
        {

            /*int SpawnPointX = Random.Range(0, 11);
            int SpawnPointZ = Random.Range(0, 11);
            int SpawnPointY = Random.Range(0, 11);

            Vector3 SpawnPosition = new Vector3(SpawnPointX, SpawnPointY, SpawnPointZ);*/

            for (var i = 0; i <= ItemsAtSpawn; i++)
            {
                Vector3 SpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));

                //Instantiate(ItemOne, SpawnPosition, Quaternion.identity);
                Instantiate(ItemOne, SpawnPosition, Quaternion.identity);

                Debug.Log("Number Of Item Ones is " + i);
            }
        }

        public void SpawnItemOne()
        {
            Vector3 SpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));

            Instantiate(ItemOne, SpawnPosition, Quaternion.identity);
        }

        public void SpawnItemTwoAtStart()
        {

            for (var i = 0; i <= ItemsAtSpawn; i++)
            {
                Vector3 SpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));

                Instantiate(ItemTwo, SpawnPosition, Quaternion.identity);

                //Debug.Log(i);
            }
        }

        public void SpawnItemTwo()
        {
            Vector3 SpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));

            Instantiate(ItemTwo, SpawnPosition, Quaternion.identity);
        }

        /*public void SpawnItemThreeAtStart()
        {

            for (var i = 0; i <= ItemsAtSpawn; i++)
            {
                Vector3 SpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));

                Instantiate(ItemThree, SpawnPosition, Quaternion.identity);
            }
        }

        public void SpawnItemThree()
        {
            Vector3 SpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));

            Instantiate(ItemThree, SpawnPosition, Quaternion.identity);
        }

        public void SpawnItemFourAtStart()
        {

            for (var i = 0; i <= ItemsAtSpawn; i++)
            {
                Vector3 SpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));

                Instantiate(ItemFour, SpawnPosition, Quaternion.identity);
            }
        }
        
         public void SpawnItemFour()
        {
            Vector3 SpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));

            Instantiate(ItemFour, SpawnPosition, Quaternion.identity);
        }*/
    }
}
