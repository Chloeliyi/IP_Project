using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Chloe Chan

namespace CollectionSystem
{
    //Car effects for smoke and spark
    public class CarEffects : MonoBehaviour
    {
        public ParticleSystem[] Smoke;
        public ParticleSystem[] Spark;
        private CarAI _CarAI;

        //private TestSlider _Slider;
        private CarController _CarController;

        private void Start()
        {
            _CarAI = GetComponent<CarAI>();
            //_Slider = GetComponent<TestSlider>();
            _CarController = GetComponent<CarController>();
        }

        public void StartSmoke()
        {
            for (int i = 0; i < Smoke.Length; i++)
            {
                Smoke[i].Play();
            }
        }

        public void StopSmoke()
        {
            for (int i = 0; i < Smoke.Length; i++)
            {
                Smoke[i].Stop();
            }
        }

        public void StartSpark()
        {
            for (int i = 0; i < Spark.Length; i++)
            {
                Spark[i].Play();
            }
        }
        public void StopSpark()
        {
            for (int i = 0; i < Spark.Length; i++)
            {
                Spark[i].Stop();
            }
        }

        private void FixedUpdate()
        {
            if(_CarAI.PlayPauseSmoke)
                StartSmoke();
            else
                StopSmoke();

            if (_CarController.PlayPauseSpark)
                StartSpark();
            else
                StopSpark();
        }
    }
}
