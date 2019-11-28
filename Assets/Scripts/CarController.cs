using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : PlayerController
{
  public List<AxleInfo> axleInfos; // the information about each individual axle
  public float maxMotorTorque; // maximum torque the motor can apply to wheel
  public float maxSteeringAngle; // maximum steer angle the wheel can have
  public float antiRoll = 5000.0f;

  public void FixedUpdate()
  {
    float motor = maxMotorTorque * Input.GetAxis("Vertical");
    float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

    foreach (AxleInfo axleInfo in axleInfos)
    {
      WheelHit hit;
      float travelL = 1.0f;
      float travelR = 1.0f;

      bool groundedL = axleInfo.leftWheel.GetGroundHit(out hit);
      bool groundedR = axleInfo.rightWheel.GetGroundHit(out hit);

      if (groundedL) {
        travelL = (-axleInfo.leftWheel.transform.InverseTransformPoint(hit.point).y - axleInfo.leftWheel.radius) / axleInfo.leftWheel.suspensionDistance;
      }

      if (groundedR) {
        travelR = (-axleInfo.rightWheel.transform.InverseTransformPoint(hit.point).y - axleInfo.rightWheel.radius) / axleInfo.rightWheel.suspensionDistance;
      }

      float antiRollForce = (travelL - travelR) * antiRoll;

      if (groundedL) {
        GetComponent<Rigidbody>().AddForceAtPosition(
          axleInfo.leftWheel.transform.up * -antiRollForce,
          axleInfo.leftWheel.transform.position
        );
      }

      if (groundedR) {
        GetComponent<Rigidbody>().AddForceAtPosition(
          axleInfo.rightWheel.transform.up * antiRollForce,
          axleInfo.rightWheel.transform.position
        );
      }

      if (axleInfo.steering)
      {
        axleInfo.leftWheel.steerAngle = steering;
        axleInfo.rightWheel.steerAngle = steering;
      }

      if (axleInfo.motor)
      {
        axleInfo.leftWheel.motorTorque = motor;
        axleInfo.rightWheel.motorTorque = motor;
      }
    }
  }
}


[System.Serializable]
public class AxleInfo
{
  public WheelCollider leftWheel;
  public WheelCollider rightWheel;
  public bool motor; // is this wheel attached to motor?
  public bool steering; // does this wheel apply steer angle?
}
