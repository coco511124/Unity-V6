using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Ditzelgames;

public class VRBoatController : MonoBehaviour
{
    public HingeJoint steeringWheel;
    public float maxTurnAngle = 180;

    //visible Properties
    public Transform Motor;
    public float SteerPower = 500f;
    public float Power = 5f;
    public float MaxSpeed = 10f;
    //public float Drag = 0.1f;

    //used Components
    public Rigidbody boatRigidbody;
    public Quaternion StartRotation;

    public InputActionProperty SpeedTrigger;
    public InputActionProperty BreakTrigger;

    //
    public bool CanControll = false;

    private void Awake()
    {
        boatRigidbody = GetComponent<Rigidbody>();
        StartRotation = Motor.localRotation;
    }

    private void FixedUpdate()
    {
        float h = Mathf.Clamp(steeringWheel.angle/maxTurnAngle, -1, 1);
        //Debug.Log(h);

        var forceDirection = transform.forward;
        var steer = 0;

        ////steer direction [-1,0,1]
        if (Input.GetKey(KeyCode.A) || -0.5 > h)
        {
            steer = 1;
        }
        if (Input.GetKey(KeyCode.D) || 0.5 < h)
        {
            steer = -1;
        }
        //compute vectors
        var forward = Vector3.Scale(new Vector3(1, 0, 1), transform.forward);
        var targetVel = Vector3.zero;



        //forward/backward poewr
        float speedValue = SpeedTrigger.action.ReadValue<float>();
        float breakValue = BreakTrigger.action.ReadValue<float>();

        if(CanControll == true)
        {
            //Rotational Force
            boatRigidbody.AddForceAtPosition(steer * transform.right * SteerPower / 100f, Motor.position);


            if (Input.GetKey(KeyCode.W) || speedValue > 0.3)
            {
                PhysicsHelper.ApplyForceToReachVelocity(boatRigidbody, forward * MaxSpeed, Power);
                Debug.Log("«e¶i");
            }

            if (Input.GetKey(KeyCode.S) || breakValue > 0.3)
            {
                PhysicsHelper.ApplyForceToReachVelocity(boatRigidbody, forward * -MaxSpeed, Power);
            }
        }                          
    }
}
