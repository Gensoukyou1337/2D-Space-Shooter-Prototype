using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float baseSpeed;
	public float rotSpeed;
	public float shipBoundRad;

	void Start () {
	
	}
	
	// Update is generally useful for player input.
	// Physics-based stuff, however, LOVES FixedUpdate - updates every tick in the physics engine.
	void Update ()
	{
		//Input.GetKey() = is the key down? - also, it CAN'T BE RE-MAPPED.
		//Input.GetKeyDown() = is the key down on THIS FRAME [only triggers once]?
		//Input.GetKeyUp() = is the key released on THIS FRAME [only triggers once]?
		//Names of axes are in Project Settings -> Input
		//Important: Gravity, Sensitivity

		//For Rotation
		//Grab rotation quaternion
		Quaternion rot = transform.rotation;
		//Grab Z angle
		float z = rot.eulerAngles.z;
		//Change Z angle on input
		z -= Input.GetAxis ("Horizontal") * Time.deltaTime * rotSpeed;
		//recreate quaternion
		rot = Quaternion.Euler (0, 0, z);
		transform.rotation = rot;

		Vector3 pos = transform.position;

		float throttle = Input.GetAxis ("Vertical");
		float throttleSpeed;
		if (throttle > 0f) {
			throttleSpeed = Input.GetAxis ("Vertical") * Time.deltaTime * baseSpeed;
		} else if (throttle < 0f) {
			throttleSpeed = Input.GetAxis ("Vertical") * Time.deltaTime * baseSpeed * 0.6f;
		} else {
			throttleSpeed = 0f;
		}
		Vector3 velocity = new Vector3 (0, throttleSpeed, 0);
		pos += rot * velocity;
		//pos.x += Input.GetAxis ("Horizontal") * Time.deltaTime * baseSpeed;

		//Restricting player inside camera
		//Orthographic Size determines Y boundary
		if (pos.y > (Camera.main.orthographicSize - shipBoundRad)) { //Camera.main returns camera tagged as 'Main Camera'.
			pos.y = Camera.main.orthographicSize - shipBoundRad;
		}
		if (pos.y < -(Camera.main.orthographicSize - shipBoundRad)) {
			pos.y = -(Camera.main.orthographicSize - shipBoundRad);
		}

		float screenRatio = (float)Screen.width / (float)Screen.height; //calculate screen ratio for use in the same camera bounding FOR X
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		if ((pos.x + shipBoundRad) > widthOrtho)
		{
			pos.x = widthOrtho - shipBoundRad;
		}
		if ((pos.x - shipBoundRad) < -widthOrtho)
		{
			pos.x = -widthOrtho + shipBoundRad;
		}

		transform.position = pos;
	}
}
