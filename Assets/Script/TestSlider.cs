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

        private CarControllerAI Carfixed;

        //private WheelController _Car;

        void Awake()
        {
            GetComponent<TestSlider>().enabled = false;
            //_Car = GetComponent<WheelController>();

            _fixSlider.SetActive(false);

            Carfixed = GetComponent<CarControllerAI>();
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

                    Debug.Log("Car is fixed");

                    //_keyInventory.hasCar = true;
                    //Debug.Log("Has Car is " + _keyInventory.hasCar);

                    GetComponent<CarControllerAI>().enabled = true;
                    Carfixed.CarIsRepaired();

                    //GetComponent<WheelController>().enabled = true;
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
