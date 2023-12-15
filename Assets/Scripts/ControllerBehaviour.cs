using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBehaviour : MonoBehaviour {
    [SerializeField] float jumpHeight = 1.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
		{
            transform.position += jumpHeight*Vector3.up;
        }

        if (OVRInput.Get(OVRInput.Touch.PrimaryTouchpad))
        {
            Vector2 direction = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            transform.position += new Vector3(direction.x,0.0f,direction.y)*0.2f ;
        }
    }
}
