using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

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

	// clone
	public GameObject theObject;

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
			Manipulate.translate = true;
		} else {
			Manipulate.translate = false;
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

			if(Manipulate.scale) {
				Manipulate.scale = false;
			} else {
				Manipulate.scale = true;
			}
			
		}
		
		if (GUI.Button (new Rect (10, 280, 280, 120), "Rotate", myStyle)) {
			Debug.Log("Hit Rotate");
			if(Manipulate.rotate) {
				Manipulate.rotate = false;
			} else {
				Manipulate.rotate = true;
			}
		}

		if (GUI.Button (new Rect (10, 410, 280, 120), "Clone", myStyle)) {
			Debug.Log("Hit Clone");


			// this crashes
//			Transform myModelTrf = GameObject.Instantiate(gameObject) as Transform;
//			
//			myModelTrf.parent = gameObject.transform;             
//			myModelTrf.localPosition = new Vector3(0f, 0f, 0f);
//			myModelTrf.localRotation = Quaternion.identity;
//			myModelTrf.localScale = new Vector3(0.5f, 0.5f, 0.5f);
//			
//			myModelTrf.gameObject.active = true;



//			GameObject instance = (GameObject)Instantiate(gameObject, transform.position, transform.rotation);


//			GameObject clone = (GameObject)Instantiate(Resources.Load("Sphere"));
//			Instantiate(clone, new Vector3(0, 0, 0));
//
//			Transform prefab;
//			Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity) as Transform;

//			GameObject clone = (GameObject)Instantiate(Resources.Load("Sphere"));
//			Instantiate(theObject, Vector3(transform.position.x, transform.position.y, transform.localPosition.z + 1), transform.rotation);


//			GameObject clone;
//			clone = Instantiate(prefab, position, transform.rotation);
//			clone.velocity = transform.TransformDirection( Vector3 (0, 1,     speed));
//			clone.transform.parent = transform;
//			clone.transform.localPosition = position;

//			if(Manipulate.rotate) {
//				Manipulate.rotate = false;
//			} else {
//				Manipulate.rotate = true;
//			}
		}

		if (GUI.Button (new Rect (10, 540, 280, 120), "Delete", myStyle)) {
			Debug.Log("Hit Delete");

			selected = false;
			Destroy(GameObject.Find("Sphere"));

		}
		
	}
}
