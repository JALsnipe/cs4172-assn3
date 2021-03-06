﻿using UnityEngine;
using System.Collections;

public class ControlCustomTwo : MonoBehaviour {
	
	// translate vars
	bool translate = false;
	public GUIText message = null;
	private Transform pickedObject = null;
	private Vector3 lastPlanePoint;
	
	bool scale;
	bool rotate;
	
	// selection
	static public bool selected;
	private Ray m_Ray;
	private RaycastHit m_RayCastHit;
	private TouchableObject m_CurrentTouchableObject;
	
	// scale
	public static Vector3 cameraPositionAtScaleButtonTap;
	
	// GUI
	static public bool render = false;
	private Rect windowRect = new Rect (1300, 20, 300, 800);
	private GUIStyle myStyle;
	
	Rect textArea = new Rect(890,0,Screen.width, Screen.height);
	
	public Material defaultMaterial;

	// Clone
	public Transform prefab;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// Selection handeled in Manipulate.cs
		if (selected) {
			ShowWindow();
		}
		
		if (!selected) {
			HideWindow();
		}
		
		// Translation
		if (translate) {
			// translation handled by Manipulate.cs
			ManipulateCustomTwo.translate = true;
		} else {
			ManipulateCustomTwo.translate = false;
		}
		
		// Rotation handeled in Manipulate.cs
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
				GUI.Label(textArea, "Translate");
			}
			
			if (Scale.scale) {
				GUI.Label(textArea, "Scale");
			}
		}
	}
	
	public void DoMyWindow(int windowID) {
		if (GUI.Button (new Rect (10, 20, 280, 120), "Translate", myStyle)) {
			Debug.Log("Hit Translate");
			
			if(translate) {
				translate = false;
			} else {
				translate = true;
			}
		}
		
		if (GUI.Button (new Rect (10, 150, 280, 120), "Scale", myStyle)) {
			Debug.Log("Hit Scale");
			cameraPositionAtScaleButtonTap = gameObject.transform.position;
			Debug.Log("cameraPosition: " + cameraPositionAtScaleButtonTap);
			
			if(ManipulateCustomTwo.scale) {
				ManipulateCustomTwo.scale = false;
			} else {
				ManipulateCustomTwo.scale = true;
			}
			
		}
		
		if (GUI.Button (new Rect (10, 280, 280, 120), "Rotate", myStyle)) {
			Debug.Log("Hit Rotate");
			if(ManipulateCustomTwo.rotate) {
				ManipulateCustomTwo.rotate = false;
			} else {
				ManipulateCustomTwo.rotate = true;
			}
		}

		if (GUI.Button (new Rect (10, 410, 280, 120), "Clone", myStyle)) {
			Debug.Log("Hit Clone");

			Transform t = (Transform) Instantiate(prefab, GameObject.Find("Sphere001").transform.position, GameObject.Find("Sphere001").transform.rotation);
			t.transform.localScale = GameObject.Find("Sphere001").transform.localScale;
			t.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
			Debug.Log("t.transform.localScale: " + t.transform.localScale);
			
			// this crashes
			//			Transform myModelTrf = GameObject.Instantiate(gameObject) as Transform;
			//			
			//			myModelTrf.parent = gameObject.transform;             
			//			myModelTrf.localPosition = new Vector3(0f, 0f, 0f);
			//			myModelTrf.localRotation = Quaternion.identity;
			//			myModelTrf.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			//			
			//			myModelTrf.gameObject.active = true;
			
		}
		
		if (GUI.Button (new Rect (10, 540, 280, 120), "Delete", myStyle)) {
			Debug.Log("Hit Delete");
			
			selected = false;
			Destroy(GameObject.Find("Sphere001"));
			
		}
		
	}
}
