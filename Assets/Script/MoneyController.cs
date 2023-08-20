using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
//Chloe Chan
namespace CollectionSystem
{
    //Check for how much money there is
    public class MoneyController : MonoBehaviour
    {
        public static MoneyController instance;
        public int MoneyAmount { get; set; }
        public int AddMoney = 1000;
        public int minusMoney = 5000;
             
        public UnityEvent<MoneyController> OnMoneyUpdate;
        // Start is called before the first frame update
        void Start()
        {
            MoneyAmount = 5000;
            instance = this;
        }
        //Add money earned
        public void PlusMoney()
        {
            MoneyAmount += AddMoney;
            OnMoneyUpdate.Invoke(this);
        }
        //Minus money used
        public void MinusMoney()
        {
            MoneyAmount -= minusMoney;

            OnMoneyUpdate.Invoke(this);
        }
    } 
}