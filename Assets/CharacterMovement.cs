using UnityEngine;
using System.Collections;

using UnityEngine.VR;

public class CharacterMovement : MonoBehaviour {

	CharacterController controller;
	public Camera mainCamera;
	public GhostTexture hauntedWhiteBoard;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();


		VRSettings.renderScale = 0.3f;
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown(KeyCode.R) ) { // let user recenter camera if they want to
			InputTracking.Recenter();
		}

		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");

		// move forward in the direction that the VR headset is looking
		controller.Move( vertical * Camera.main.transform.forward * Time.deltaTime * 10f + Physics.gravity);
		// turn left or right
		transform.Rotate( 0f, horizontal * Time.deltaTime * 100f, 0f );
		RaycastHit hit;
		Ray PsychicRay = new Ray(mainCamera.transform.position, mainCamera.transform.forward);

		if(Physics.Raycast(PsychicRay, out hit, 40f)){
			if(hit.collider.tag == "whiteboard"){
				Debug.Log("hit whiteboard");
			}
			else if(hit.collider.tag == "wall") {
				hauntedWhiteBoard.hideSkulls();
			}
		}
		Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * 100f);
	}
}
