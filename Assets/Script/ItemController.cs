using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CollectionSystem
{
    public class ItemController : MonoBehaviour
    {

        [SerializeField] private bool ItemOne = false;
        [SerializeField] private bool ItemTwo = false;

        [SerializeField] private Inventory _keyInventory = null;

        // Start is called before the first frame update
        void Start()
        {

        }

        public void ObjectInteraction()
        {
            if(ItemOne)
            {
                _keyInventory.hasItemOne = true;
                Debug.Log(gameObject.name);
                gameObject.SetActive(false);
            }
            else if (ItemTwo)
            {
                _keyInventory.hasItemTwo = true;
                Debug.Log(gameObject.name);
                gameObject.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
