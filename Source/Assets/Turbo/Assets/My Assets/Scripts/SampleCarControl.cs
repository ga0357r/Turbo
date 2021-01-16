using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AxleInfo
{
    //thye direction of the motor wheels
    public string directionName;
    //a reference to the wheel collider for the left wheel
    public WheelCollider leftWheel;
    //a reference to the wheel collider for the right wheel
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // do these wheels apply steer angle?
    public float wheel_rotation_y = 90f;
}

public class SampleCarControl : MonoBehaviour
{
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque or rotational force the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);



        visualWheel.transform.position = position ;
        visualWheel.transform.rotation = rotation * Quaternion.Euler(0f, 0f, 90f);
    }

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
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
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }
}
