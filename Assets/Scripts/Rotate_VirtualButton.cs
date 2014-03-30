﻿using UnityEngine;
using System.Collections;

// http://forum.unity3d.com/threads/144687-Vuforia-Virtual-Buttons-anyone?p=1567421&viewfull=1#post1567421

public class Rotate_VirtualButton : MonoBehaviour, IVirtualButtonEventHandler
	
{
	
	// Use this for initialization
	
	void Start () {
		
		
		
		// here it finds any VirtualButton Attached to the ImageTarget and register it's event handler and in the 
		
		//OnButtonPressed and OnButtonReleased methods you can handle different buttons Click state
		
		//via "vb.VirtualButtonName" variable and do some really awesome stuff with it.
		
		VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
		
		foreach (VirtualButtonBehaviour item in vbs)
		{
			
			item.RegisterEventHandler(this);
		}
	}
	
	// Update is called once per frame
	
	void Update () {
		
	}
	
	#region VirtualButton
	
	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
	{
		
		Debug.Log("Helllllloooooooooo");
		Scale.rotate = true;
		
	}
	
	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
	{
		
		Debug.Log("Goooooodbyeeee");
		Scale.rotate = false;
		
	}
	
	
	
	#endregion //VirtualButton
	
}