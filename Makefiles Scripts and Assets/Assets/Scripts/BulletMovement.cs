using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public float baseSpeed;

	// Update is called once per frame
	void Update ()
	{
		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3 (0, Time.deltaTime * baseSpeed, 0);
		pos += transform.rotation * velocity;
		transform.position = pos;
	}
}
