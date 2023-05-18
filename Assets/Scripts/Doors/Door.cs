using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : DoorBase
{
    [SerializeField]
    HingeJoint leftHingeJoint;

    [SerializeField]
    HingeJoint rightHingeJoint;


    [SerializeField]
    Renderer leftDoorRenderer;

    [SerializeField]
    Renderer rightDoorRenderer;

    // to control rotation of the doors
    JointLimits leftJointLimits;

    JointLimits rightJointLimits;


    // Start is called before the first frame update
    void Start()
    {
        // set the color of the door
        leftDoorRenderer.material.SetColor("_Color", GetColor());
        rightDoorRenderer.material.SetColor("_Color", GetColor());


        leftJointLimits = leftHingeJoint.limits;
        rightJointLimits = rightHingeJoint.limits;

        LockDoor();
    }

    public void LockDoor()
    {
        // setting max and min 0 to stop movement unless player got the key of the door
        leftJointLimits.max = 0;
        rightJointLimits.min = 0;

        // assign back to the hinge joint limits
        leftHingeJoint.limits = leftJointLimits;
        rightHingeJoint.limits = rightJointLimits;
    }

    public void UnlockDoor()
    {
        leftJointLimits.max = 90;
        rightJointLimits.min = -90;
        leftHingeJoint.limits = leftJointLimits;
        rightHingeJoint.limits = rightJointLimits;
    }
}
