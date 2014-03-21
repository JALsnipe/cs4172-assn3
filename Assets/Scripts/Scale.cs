using UnityEngine;
using System.Collections;

public class Scale : MonoBehaviour {

	Vector3 cameraPosition;
	Vector3 objectPosition;
	public GameObject tracked;

	// Use this for initialization
	void Start () {
		cameraPosition = transform.position;
		objectPosition = tracked.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

//		cameraPosition = gameObject.transform.position;
//		objectPosition = tracked.transform.position;

		print (tracked.transform.localScale);

		//this is wrong, debug

		if (cameraPosition.y > 400.0 && cameraPosition.y < 500.0) {
			if(tracked.transform.localScale.y < 2.0) {
				tracked.transform.localScale += new Vector3(0.1F, 0.1F, 0.1F);
			}
		}

		if (cameraPosition.y > 500.0 && cameraPosition.y < 600.0) {
			if(tracked.transform.localScale.y < 3.0) {
				tracked.transform.localScale += new Vector3(0.1F, 0.1F, 0.1F);
			}
		}

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
