using UnityEngine;
using System.Collections;

public class Scale : MonoBehaviour {

	Vector3 cameraPosition;
	Vector3 objectPosition;
	public GameObject tracked;

	bool target_tracked;

	float objScale;

	//bools
	bool rotate;
	bool translate;
	bool scale;

	// Use this for initialization
	void Start () {
		cameraPosition = transform.position;
		objectPosition = tracked.transform.position;
	}

	public void OnTrackingFound()
	{
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer>();
		
		foreach (Renderer component in rendererComponents) {
			component.enabled = true;
		}

		
//		print("Trackable " + mTrackableBehaviour.TrackableName + " found");
		print ("Trackable found");
	}
	
	// Update is called once per frame
	void Update () {

		cameraPosition = gameObject.transform.position;
//		objectPosition = tracked.transform.position;

//		print (tracked.transform.localScale);

		//if object is tracked
		//get camera y position
		//somehow map that to object scale
		//set min and max scale values

		//get camera transform y val
		//divide by 200 to get object scale value

//		if (DefaultTrackableEventHandler.mTrackableBehaviour.TrackableName == "chips") {
//		}

		// this is not entirely correct, should be x y (z?) average?
		objScale = cameraPosition.y / 150.0F;

//		print ("scale: " + objScale);

//		tracked.transform.Rotate (Vector3.right * Time.deltaTime);

		//ideas
		//virtualbuttons for transform, scale, rotate?
		// use unity buttons for now?

//		rotate = true;

		//this works
		if (rotate) {
			tracked.transform.localRotation = Quaternion.AngleAxis (1, Vector3.up) * tracked.transform.localRotation;
		}

		scale = true;

		// this works
		if (scale) {
			tracked.transform.localScale = new Vector3 (objScale, objScale, objScale);
		}



		//this is wrong, debug
		if (target_tracked) {
			tracked.transform.localScale += new Vector3 (0.01F, 0.01F, 0.01F);
		}

//		if (cameraPosition.y > 400.0 && cameraPosition.y < 500.0) {
//			if(tracked.transform.localScale.y < 2.0) {
//				tracked.transform.localScale += new Vector3(0.1F, 0.1F, 0.1F);
//			}
//		}
//
//		if (cameraPosition.y > 500.0 && cameraPosition.y < 600.0) {
//			if(tracked.transform.localScale.y < 3.0) {
//				tracked.transform.localScale += new Vector3(0.1F, 0.1F, 0.1F);
//			}
//		}

//		if (cameraPosition.y < transform.position.y) {
//			tracked.transform.localScale += new Vector3(0.1F, 0, 0);
//		}
//
//		if (cameraPosition.y > transform.position.y) {
//			tracked.transform.localScale -= new Vector3(0.1F, 0, 0);
//		}

		//if disctance of camera is increasing from gameobject
		// transform.localScale += new Vector3(0.1F, 0, 0);
		//if distance of camera is decreasing from gameobject
		// transform.localScale -= new Vector3(0.1F, 0, 0);
	
	}
}
