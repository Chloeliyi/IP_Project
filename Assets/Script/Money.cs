using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CollectionSystem
{
    public class Money : MonoBehaviour
    {
        private TextMeshProUGUI AmountOfMoney;

        // Start is called before the first frame update
        void Start()
        {
            AmountOfMoney = GetComponent<TextMeshProUGUI>();
        }

        public void UpdateMoney(MoneyController MoneyController)
        {
            AmountOfMoney.text = "Money: $" + MoneyController.MoneyAmount.ToString();
        }
    }
}
