using UnityEngine;
using System.Collections;

// http://answers.unity3d.com/questions/297066/drag-object-not-working-in-vuforia-.html

// highlighting https://developer.vuforia.com/forum/unity-3-extension-technical-discussion/how-add-touch-listener-3d-object-unity

public class Manipulate : MonoBehaviour 
{
	private Ray m_Ray;
	private RaycastHit m_RayCastHit;
	private TouchableObject m_CurrentMovableObject;
	private float   m_MovementMultipier = 10f;

	public static bool translate;

	// selection
	bool isSelected = false;
	Material originalMaterial;
	Material redMaterial;
	MeshRenderer meshRenderer;

	bool selectMode = false;
	
	GameObject baseObject;
	string obj_name;

	void Start () {
		obj_name        = this.gameObject.name;
		baseObject      = GameObject.Find( obj_name );
		meshRenderer        = baseObject.GetComponent<MeshRenderer>();
		originalMaterial    = meshRenderer.material;
		
		Color red           = new Color(255.0f,0.0f,0.0f, 0.5f);
		redMaterial         = new Material(Shader.Find("Transparent/Parallax Specular"));
		redMaterial.color   = red;
	}
	
	void Update () {
		if (translate) {
			// can no longer toggle selection on object
			selectMode = false;
			if (Input.touches.Length == 1) {
				Debug.Log("In Input.touches.Length == 1");
				Touch touchedFinger = Input.touches[0];
				
				switch (touchedFinger.phase) {
				case TouchPhase.Began: 
					Debug.Log("In TouchPhase.Began");
					m_Ray = Camera.mainCamera.ScreenPointToRay(touchedFinger.position);
					if (Physics.Raycast(m_Ray.origin, m_Ray.direction, out m_RayCastHit, Mathf.Infinity)) {
						Debug.Log("In Physics.Raycast...");
						TouchableObject movableObj = m_RayCastHit.collider.gameObject.GetComponent<TouchableObject>();
						if(movableObj) {
							Debug.Log("In if(movableObj)");
							m_CurrentMovableObject = movableObj;
						}
					}
					break;
				case TouchPhase.Moved:
					Debug.Log("In TouchPhase.Moved");
					if(m_CurrentMovableObject) {
						Debug.Log("In m_CurrentMovableObject");
						m_CurrentMovableObject.gameObject.transform.Translate(Time.deltaTime * m_MovementMultipier * new Vector3(touchedFinger.deltaPosition.x, 0, touchedFinger.deltaPosition.y));
					}
					break;
					
				case TouchPhase.Ended:
					Debug.Log("In TouchPhase.Ended");
					m_CurrentMovableObject = null;
					break;
				
				default:
					break;
				}
			}

			// finished translating, object is selectable again
			selectMode = true;
		}
	}

	void OnMouseDown() {
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
				
				HighlightRed();
				Control.selected = true;
			}
			
			if (isSelected == false) {
				
				RemoveHighlight();
				Control.selected = false;
			}
		}
	}
	
	void HighlightRed(){
		
		meshRenderer.material = redMaterial;
		Debug.Log("IT SHOULD BE RED");
	}
	
	void RemoveHighlight(){
		
		meshRenderer.material = originalMaterial;
	}
}