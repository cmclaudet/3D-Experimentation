﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;
 
	private SteamVR_Controller.Device Controller
	{
	    get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}

	private GameObject collidingObject; 
// 2
	private GameObject objectInHand;

	void Awake()
	{
	    trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	private void SetCollidingObject(Collider col)
	{
    	// 1
    	if (collidingObject || !col.GetComponent<Rigidbody>())
    	{
    	    return;
    	}
    // 2
    	collidingObject = col.gameObject;
	}

	public void OnTriggerEnter(Collider other)
	{
	    SetCollidingObject(other);
	}
 
	public void OnTriggerStay(Collider other)
	{
	    SetCollidingObject(other);
	}
 
	public void OnTriggerExit(Collider other)
	{
    	if (!collidingObject)
    	{
    	    return;
    	}
 
    	collidingObject = null;
	}

	private void GrabObject()
	{
    // 1
	    objectInHand = collidingObject;
	    collidingObject = null;
    // 2
	    var joint = AddFixedJoint();
	    joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
	}
 
	private FixedJoint AddFixedJoint()
	{
	    FixedJoint fx = gameObject.AddComponent<FixedJoint>();
	    fx.breakForce = 20000;
	    fx.breakTorque = 20000;
	    return fx;
	}

	private void ReleaseObject()
	{
    // 1
	    if (GetComponent<FixedJoint>())
	    {
        // 2
	        GetComponent<FixedJoint>().connectedBody = null;
	        Destroy(GetComponent<FixedJoint>());
        // 3
	        objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
	        objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
	    }
    // 4
    	objectInHand = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (Controller.GetHairTriggerDown())
		{
    		if (collidingObject)
    		{
    		    GrabObject();
    		}
		}
 
// 2
		if (Controller.GetHairTriggerUp())
		{
    		if (objectInHand)
    		{
    		    ReleaseObject();
    		}
		}
	}
}
