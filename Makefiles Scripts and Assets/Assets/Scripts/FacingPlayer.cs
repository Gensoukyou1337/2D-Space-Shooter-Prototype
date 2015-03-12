using UnityEngine;
using System.Collections;

public class FacingPlayer : MonoBehaviour {

	public float rotSpeed = 90;

	//Below this line should be good for turrets

	private Transform player;
	
	void Update ()
	{
		//Search for GameObject named "PlayerShip"
		if (player == null) {
			GameObject go = GameObject.Find ("PlayerShip");
			if (go != null) {
				player = go.transform;
				//Sets transform target to Player's
			}
		}

		if(player == null)
		{
			return; //Do nothing this frame, repeat next
		}

		//If player != null
		Vector3 dir = player.position - transform.position;
		dir.Normalize ();
		float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90; //Because up is 90 degrees from the 0 degree orientation

		//transform.rotation = Quaternion.Euler (0, 0, zAngle);

		//Above this line should be good for turrets

		Quaternion desiredRot = Quaternion.Euler (0, 0, zAngle);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
	}
}
