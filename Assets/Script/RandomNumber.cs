using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace CollectionSystem
{

    public class RandomNumber : MonoBehaviour
    {
        public TextMeshProUGUI ToBeCollectedLabel;
        public int RandomCollect;
        void Awake()
        {
            ToBeCollectedLabel = GetComponent<TextMeshProUGUI>();

            RandomCollectNum();
        }


        public void RandomCollectNum()
        {
            RandomCollect = Random.Range(5, 11);
            ToBeCollectedLabel.text = "/" + RandomCollect.ToString();
            Debug.Log("Random Number To Be Collected :  " + RandomCollect);
        }
    }
}
