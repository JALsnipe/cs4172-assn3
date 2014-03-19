using UnityEngine;
using System.Collections;

public class SphereSelect : MonoBehaviour {

	public bool sphereClicked;

	Material defaultMaterial;

	// Use this for initialization
	void Start () {

		sphereClicked = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit) && hit.collider.gameObject.name == "Sphere") {
				
				if (sphereClicked == false) {
					sphereClicked = true;
					renderer.material.color = Color.green;
//					pausePlanets ();
				}
				
				//				if (sunClicked == true) {
				else {
					sphereClicked = false;
					renderer.material = defaultMaterial;
//					resumePlanets ();
				}
				
			}
			
		}
	}
}
