using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Chloe Chan
//Buttons for dealer UI
namespace CollectionSystem
{
    public class DealerUI : MonoBehaviour
    {

        [SerializeField] private MoneyController _MoneyController;
        public GameObject UIForDealer;

        public Player playerScript;
        //Buy Car Button
        public void OnBuyCarButton()
        {
            Debug.Log("Car is purchased");
            _MoneyController.MinusMoney();
        }
        //Close UI Button
        public void OnCloseUI()
        {
            UIForDealer.SetActive(false);
            playerScript.PlayerMovement = true;
            //Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
