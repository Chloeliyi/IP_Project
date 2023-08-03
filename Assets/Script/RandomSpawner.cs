using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject ItemOne;

    public GameObject ItemTwo;
    //public float Radius = 1;
    int ItemsAtSpawn = 1;


    private void Start()
    {
        SpawnItemOne();
        SpawnItemTwo();
    }
    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Space))
        {

            SpawnItemOne();
            SpawnItemTwo();
        }*/
    }

    public void SpawnItemOne()
    {
        /*int SpawnPointX = Random.Range(0, 11);
        int SpawnPointZ = Random.Range(0, 11);
        int SpawnPointY = Random.Range(0, 11);

        Vector3 SpawnPosition = new Vector3(SpawnPointX, SpawnPointY, SpawnPointZ);*/

        for (var i = 0; i <= ItemsAtSpawn; i++)
        {
            Vector3 SpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));

            Instantiate(ItemOne, SpawnPosition, Quaternion.identity);

            Debug.Log(i);
        }
    }

    public void SpawnItemTwo()
    {
        /*int SpawnPointX = Random.Range(0, 11);
        int SpawnPointZ = Random.Range(0, 11);
        int SpawnPointY = Random.Range(0, 11);

        Vector3 SpawnPosition = new Vector3(SpawnPointX, SpawnPointY, SpawnPointZ);*/

        for (var i = 0; i <= ItemsAtSpawn; i++)
        {
            Vector3 SpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));

            Instantiate(ItemTwo, SpawnPosition, Quaternion.identity);

            Debug.Log(i);
        }
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }*/
}
