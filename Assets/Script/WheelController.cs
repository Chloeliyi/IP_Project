using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CollectionSystem
{
    public class WheelController : MonoBehaviour
    {
        [SerializeField] WheelCollider frontRight;
        [SerializeField] WheelCollider frontLeft;
        [SerializeField] WheelCollider backRight;
        [SerializeField] WheelCollider backLeft;

        [SerializeField] Transform frontRightTransform;
        [SerializeField] Transform frontLeftTransform;
        [SerializeField] Transform backRightTransform;
        [SerializeField] Transform backLeftTransform;

        [SerializeField] private Camera CarCamera;

        public float acceleration = 500f;
        public float breakingForce = 300f;
        public float maxTurnAngle = 15f;

        private float currentAcceleration = 0f;
        private float currentBreakForce = 0f;
        private float currentTurnAngle = 0f;

        private void FixedUpdate()
        {
            CarMovement();
        }

        void Awake()
        {
            CarCamera.gameObject.SetActive(false);
            GetComponent<WheelController>().enabled = false;
        }

        public void CarMovement()
        {
            //Get forward/reverse acceleration from the vertical axis (W and S keys)
            currentAcceleration = acceleration * Input.GetAxis("Vertical");

            //If pressing space, give currentBreakForce a value
            if (Input.GetKey(KeyCode.Space))
                currentBreakForce = breakingForce;
            else
                currentBreakForce = 0f;

            //Apply acceleration to front wheels
            frontRight.motorTorque = currentAcceleration;
            frontLeft.motorTorque = currentAcceleration;

            //Apply breaking force to all wheels
            frontRight.brakeTorque = currentBreakForce;
            frontLeft.brakeTorque = currentBreakForce;
            backRight.brakeTorque = currentBreakForce;
            backLeft.brakeTorque = currentBreakForce;

            //Steering
            currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
            frontLeft.steerAngle = currentTurnAngle;
            frontRight.steerAngle = currentTurnAngle;

            UpdateWheel(frontLeft, frontLeftTransform);
            UpdateWheel(frontRight, frontRightTransform);
            UpdateWheel(backLeft, backLeftTransform);
            UpdateWheel(backRight, backRightTransform);
        }

        void UpdateWheel(WheelCollider col, Transform trans)
        {
            //Get wheel collider state
            Vector3 position;
            Quaternion rotation;
            col.GetWorldPose(out position, out rotation);

            //Set wheel transform state
            trans.position = position;
            trans.rotation = rotation;
        }
    }
}
