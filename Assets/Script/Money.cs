using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//Chloe Chan
namespace CollectionSystem
{
    public class Money : MonoBehaviour
    {
        //Text label for amount of money
        private TextMeshProUGUI AmountOfMoney;

        void Start()
        {
            AmountOfMoney = GetComponent<TextMeshProUGUI>();
        }
        //Update amount of money through events
        public void UpdateMoney(MoneyController MoneyController)
        {
            AmountOfMoney.text = "Money: $" + MoneyController.MoneyAmount.ToString();
        }
    }
}
