using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CollectionSystem
{
    public class DealerUI : MonoBehaviour
    {

        [SerializeField] private MoneyController _MoneyController;
        public GameObject UIForDealer;

        public Player playerScript;
        public void OnBuyCarButton()
        {
            Debug.Log("Car is purchased");
            _MoneyController.MinusMoney();
        }
        public void OnCloseUI()
        {
            UIForDealer.SetActive(false);
            playerScript.PlayerMovement = true;
            //Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
