using UnityEngine;
using System.Collections;

// http://answers.unity3d.com/questions/297066/drag-object-not-working-in-vuforia-.html

// highlighting https://developer.vuforia.com/forum/unity-3-extension-technical-discussion/how-add-touch-listener-3d-object-unity

public class Manipulate : MonoBehaviour 
{
	private Ray m_Ray;
	private RaycastHit m_RayCastHit;
	private TouchableObject m_CurrentMovableObject;
	private float m_MovementMultipier = 10f;

	public static bool translate;

	// selection
	bool isSelected = false;
	Material defaultMaterial;
	Material greenMaterial;
	MeshRenderer meshRenderer;

	bool selectMode = false;
	
	GameObject baseObject;
	string obj_name;

	public Material greenMat;

	// rotation
	public static bool rotate;

	// scale
	public static bool scale;
	Vector3 cameraPosition;
	float objScale;

	void Start () {
		obj_name = this.gameObject.name;
		baseObject = GameObject.Find( obj_name );
		meshRenderer = baseObject.GetComponent<MeshRenderer>();
		defaultMaterial = renderer.material;
		
		Color green  = new Color(0.0f,255.0f,0.0f, 0.5f);
		greenMaterial = new Material(Shader.Find("Transparent/Diffuse"));
		greenMaterial.color  = green;

		greenMat = new Material (greenMat);
	}
	
	void Update () {
		if (translate) {
			// can no longer toggle selection on object
			selectMode = false;
			if (Input.touches.Length == 1) {
//				Debug.Log("In Input.touches.Length == 1");
				Touch touchedFinger = Input.touches[0];
				
				switch (touchedFinger.phase) {
				case TouchPhase.Began: 
//					Debug.Log("In TouchPhase.Began");
					m_Ray = Camera.mainCamera.ScreenPointToRay(touchedFinger.position);
					if (Physics.Raycast(m_Ray.origin, m_Ray.direction, out m_RayCastHit, Mathf.Infinity)) {
//						Debug.Log("In Physics.Raycast...");
						TouchableObject movableObj = m_RayCastHit.collider.gameObject.GetComponent<TouchableObject>();
						if(movableObj) {
//							Debug.Log("In if(movableObj)");
							m_CurrentMovableObject = movableObj;
						}
					}
					break;
				case TouchPhase.Moved:
//					Debug.Log("In TouchPhase.Moved");
					if(m_CurrentMovableObject) {
//						Debug.Log("In m_CurrentMovableObject");
						m_CurrentMovableObject.gameObject.transform.Translate(Time.deltaTime * m_MovementMultipier * new Vector3(touchedFinger.deltaPosition.x, 0, touchedFinger.deltaPosition.y));
					}
					break;
					
				case TouchPhase.Ended:
//					Debug.Log("In TouchPhase.Ended");
					m_CurrentMovableObject = null;
					break;
				
				default:
					break;
				}
			}

			// finished translating, object is selectable again
			selectMode = true;
		}

		// Rotation
		if (rotate) {
			baseObject.transform.localRotation = Quaternion.AngleAxis (1, Vector3.up) * baseObject.transform.localRotation;
		}

		// Scale
		if(scale) {
			// get the position of the camera when the user hits the scale button
			// if the user increases their distance (x/y val) from the object, increase size
			// if the user decreases their distance fromt he object, decrease size

//			cameraPosition = Control.cameraPositionAtScaleButtonTap;
			GameObject camera = GameObject.Find("ARCamera");
			cameraPosition = camera.transform.position;
//			Debug.Log("cameraPosition: " + cameraPosition);
			objScale = cameraPosition.y / 100.0F;
			baseObject.transform.localScale = new Vector3 (objScale, objScale, objScale);

			// apply scale limitations
//			if(baseObject.transform.localScale.y == 0.0f) {
//				baseObject.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
//			}
//
//			if(baseObject.transform.localScale.y == 5.0f) {
//				baseObject.transform.localScale = new Vector3 (5.0f, 5.0f, 5.0f);
//			}
//			baseObject.transform.localScale += new Vector3 (0.01f, 0.01f, 0.01f);
		}

	}

	void OnMouseDown() {
		// Selection
		Debug.Log ("selectMode: " + selectMode);
		Debug.Log ("translate: " + selectMode);
		if (translate) {
			selectMode = false;
		} else {
			selectMode = true;
		}

		if(selectMode) {
			Debug.Log("Object " + obj_name + "selected.");
			
			isSelected = !isSelected;
			
			if (isSelected == true ) {
				
				Select();
				Control.selected = true;
			}
			
			if (isSelected == false) {
				
				Deselect();
				Control.selected = false;
			}
		}
	}
	
	void Select (){
		
//		meshRenderer.material = Color.green;
		meshRenderer.material = greenMaterial;
//		meshRenderer.material = greenMat;
		Debug.Log("Object selected.");
	}
	
	void Deselect (){
		
//		meshRenderer.material = originalMaterial;
//		renderer.material = defaultMaterial;
		meshRenderer.material = defaultMaterial;
	}
}