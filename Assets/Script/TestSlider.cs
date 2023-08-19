using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CollectionSystem
{
    public class TestSlider : MonoBehaviour
    {
        [SerializeField] private Inventory _keyInventory;

        [SerializeField] private float pointerDownTimer;

        [SerializeField] private float requiredHoldTime = 2;

        [SerializeField] private Slider FixSlider;

        [SerializeField] private GameObject _fixSlider;

        [SerializeField] private CarAI Carfixed;

        [SerializeField] private CarController _CarController;

        private QuestController _Quest;

        private Money _Money;
        //private WheelController _Car;

        void Awake()
        {
            //_Car = GetComponent<WheelController>();

          //Carfixed = GetComponent<CarAI>();
         // _CarController = GetComponent<CarController>();
        }
        //Check in update if slider is pressed, hold left click for 2 seconds while playing spark effect and then turn off afterwards
        private void Update()
        {
            if (_keyInventory.IsSlider == true)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    Debug.Log("Key is down");

                    pointerDownTimer += Time.deltaTime;
                    _CarController.PlayPauseSpark = true;
                    if (pointerDownTimer > requiredHoldTime)
                    {

                        _keyInventory.IsSlider = false;
                        GetComponent<TestSlider>().enabled = false;
                        _fixSlider.SetActive(false);

                        Debug.Log("Car Is Fixed");
                        _CarController.PlayPauseSpark = false;
                        _CarController.RandomColNum = 0;
                        Carfixed.CarFixed = true;
                        Debug.Log(Carfixed.CarFixed);
                        Carfixed.Fixing();
                       _keyInventory.NumberOfCarsFixed();

                        _keyInventory.hasBlueCar = false;

                        if(Carfixed.CarFixed == true)
                        {
                            QuestController.instance.QuestCounted();
                            MoneyController.instance.PlusMoney();
                        }

                        /*if(_keyInventory.hasBlueCar == true)
                        {
                            _keyInventory.hasBlueCar = false;
                        }
                        else if (_keyInventory.hasOrangeCar == true)
                        {
                            _keyInventory.hasOrangeCar = false;
                        }*/
                    }
                }
                else if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    Debug.Log("Key is up");

                    Reset();
                }
                FixSlider.value = pointerDownTimer / requiredHoldTime;
            }

            /*if (_keyInventory.NumOfCarFixed > 1)
            {
                QuestController.instance.QuestCounted();
                _Money.MoneyPlus();
            }*/
            /*else if (_keyInventory.NumOfCarFixed > 2)
            {
                QuestController.instance.QuestCounted();
            }*/

        }
        //If left click isn't holding for 2 seconds, reset the slider value
        private void Reset()
        {
            pointerDownTimer = 0;
            FixSlider.value = pointerDownTimer / requiredHoldTime;
        }
    }
}
