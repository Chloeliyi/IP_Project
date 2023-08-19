using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Chloe Chan
public class RandomSpawner : MonoBehaviour
{
    public GameObject ItemOne;
    public GameObject ItemTwo;
    public GameObject ItemThree;
    public GameObject ItemFour;
    int ItemsAtSpawn = 4;

    private void Start()
    {
    }

    //spawn five items of four different types
    public void SpawnItemOneAtStart()
    {

        for (var i = 0; i <= ItemsAtSpawn; i++)
        {
            Vector3 SpawnPosition = new Vector3(Random.Range(-125, -185), 1, Random.Range(35, 60));

            Instantiate(ItemOne, SpawnPosition, Quaternion.identity);
        }
    }
    //spawn item again after collection
    public void SpawnItemOne()
    {
        Vector3 SpawnPosition = new Vector3(Random.Range(-125, -185), 1, Random.Range(35, 60));

        Instantiate(ItemOne, SpawnPosition, Quaternion.identity);
    }

    public void SpawnItemTwoAtStart()
    {

        for (var i = 0; i <= ItemsAtSpawn; i++)
        {
            Vector3 SpawnPosition = new Vector3(Random.Range(-125, -185), 1, Random.Range(35, 60));

            Instantiate(ItemTwo, SpawnPosition, Quaternion.identity);
        }
    }

    public void SpawnItemTwo()
    {
        Vector3 SpawnPosition = new Vector3(Random.Range(-125, -185), 1, Random.Range(35, 60));

        Instantiate(ItemOne, SpawnPosition, Quaternion.identity);
    }

    public void SpawnItemThreeAtStart()
    {

        for (var i = 0; i <= ItemsAtSpawn; i++)
        {
            Vector3 SpawnPosition = new Vector3(Random.Range(-125, -185), 1, Random.Range(35, 60));

            Instantiate(ItemThree, SpawnPosition, Quaternion.identity);
        }
    }

    public void SpawnItemThree()
    {
        Vector3 SpawnPosition = new Vector3(Random.Range(-125, -185), 1, Random.Range(35, 60));

        Instantiate(ItemOne, SpawnPosition, Quaternion.identity);
    }

    public void SpawnItemFourAtStart()
    {

        for (var i = 0; i <= ItemsAtSpawn; i++)
        {
            Vector3 SpawnPosition = new Vector3(Random.Range(-125, -185), 1, Random.Range(35, 60));

            Instantiate(ItemFour, SpawnPosition, Quaternion.identity);
        }
    }
    public void SpawnItemFour()
    {
        Vector3 SpawnPosition = new Vector3(Random.Range(-125, -185), 1, Random.Range(35, 60));

        Instantiate(ItemOne, SpawnPosition, Quaternion.identity);
    }
}
