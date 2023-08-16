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

        //private WheelController _Car;

        void Awake()
        {
            //_Car = GetComponent<WheelController>();

            //_fixSlider.SetActive(false);
            //GetComponent<TestSlider>().enabled = false;

          //Carfixed = GetComponent<CarAI>();
         // _CarController = GetComponent<CarController>();
        }
        private void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Debug.Log("Key is down");

                pointerDownTimer += Time.deltaTime;
                if (pointerDownTimer > requiredHoldTime)
                {

                    _keyInventory.IsSlider = false;
                    GetComponent<TestSlider>().enabled = false;
                    _fixSlider.SetActive(false);

                    _CarController.RandomColNum = 0;
                    Carfixed.CarFixed = true;
                    Carfixed.Fixing();
                    _keyInventory.NumberOfCarsFixed();
                    QuestController.instance.QuestCounted();

                    //_keyInventory.hasCar = true;
                    //Debug.Log("Has Car is " + _keyInventory.hasCar);
                    //GetComponent<WheelController>().enabled = true;

                    //GetComponent<CarControllerAI>().enabled = true;
                    //Carfixed.CarIsRepaired();
                }
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                Debug.Log("Key is up");

                Reset();
            }
            FixSlider.value = pointerDownTimer / requiredHoldTime;
        }

        private void Reset()
        {
            pointerDownTimer = 0;
            FixSlider.value = pointerDownTimer / requiredHoldTime;
        }
    }
}
