using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System;

public class ControllerBehaviour : MonoBehaviour
{
    [SerializeField] float jumpHeight = 0.75f;
    [SerializeField] float rotDeg = 10.0f;
    [SerializeField] int maxSuccessiveJumps = 2;
    int currentJumps = 0;
    float speed = 0.1f;
    float rotThresh = 10.0f;
    bool limitedJump = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y == 0)
            currentJumps = 0;
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            if (!limitedJump || currentJumps < maxSuccessiveJumps)
            {
                transform.position += new Vector3(0.0f, jumpHeight, 0.0f);
                currentJumps++;
            }

        }
        if (OVRInput.Get(OVRInput.Touch.One))
        {
            Vector2 axis = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            Vector3 d = speed * (transform.right * axis.x + transform.forward * axis.y);
            transform.position += d;
        }

        Vector3 angle = InputTracking.GetLocalRotation(XRNode.Head).eulerAngles;
        if (angle.y > 180)
            angle.y -= 360;

        // threshhold for rotation
        
        if (Math.Abs(angle.y) > rotThresh)  
        {
            if (angle.y > 0)
                transform.Rotate(new Vector3(0.0f, angle.y - rotThresh, 0.0f));
            else
                transform.Rotate(new Vector3(0.0f, angle.y + rotThresh, 0.0f));

        }
        

        
         
    }
}
