using UnityEngine;
using System.Collections;

public class Select : MonoBehaviour {

	// GUI
	static public bool render = false;
	private Rect windowRect = new Rect (1300, 20, 300, 800);
	private GUIStyle myStyle;
	
	Rect textArea = new Rect(890,0,Screen.width, Screen.height);

	public Material defaultMaterial;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
//			Debug.Log ("tap");
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit) && hit.collider.gameObject.name == "Sphere") {
				Debug.Log("hit sphere");
				
				if (render == false) {
					//					paused = true;
					renderer.material.color = Color.green;
					render = true;
					//					PausePlanet ();
				}
				
				//				if (sunClicked == true) {
				else {
					//					render = false;
					renderer.material = defaultMaterial;
					render = false;
					//					ResumePlanet ();
				}
				
			}
			
		}

	
	}

	public void ShowWindow() {
		render = true;
	}
	
	public void HideWindow() {
		render = false;
	}
	
	public void OnGUI() {
		
		GUI.skin.label.fontSize = 30;
		myStyle = new GUIStyle(GUI.skin.button);
		myStyle.fontSize = 30;
		
		if (render) {
			windowRect = GUI.Window (0, windowRect, DoMyWindow, "Object Control");
		}
		
		if (render) {
			if (Scale.rotate) {
				GUI.Label(textArea, "Rotate");
			}
			
			if (Scale.translate) {
				GUI.Label(textArea, "Rotate");
			}
			
			if (Scale.scale) {
				GUI.Label(textArea, "Rotate");
			}
		}
	}
	
	public void DoMyWindow(int windowID) {
		if (GUI.Button (new Rect (10, 20, 280, 120), "Translate", myStyle)) {
			Debug.Log("Hit Translate");
		}
		
		if (GUI.Button (new Rect (10, 150, 280, 120), "Scale", myStyle)) {
			Debug.Log("Hit Scale");
			
		}
		
		if (GUI.Button (new Rect (10, 280, 280, 120), "Rotate", myStyle)) {
			Debug.Log("Hit Rotate");
		}
		
	}
}
