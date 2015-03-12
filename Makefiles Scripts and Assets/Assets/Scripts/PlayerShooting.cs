using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {
	public float fireCD = 0.3f;
	private float cdTimer = 0;
	public GameObject bulletPrefab;

	void Update ()
	{
		cdTimer -= Time.deltaTime;
		if (Input.GetButton ("Fire1") && cdTimer <= 0)
		{
			//shoot command
			Vector3 offset = transform.rotation * new Vector3(0, 0.72f, 0);
			Instantiate (bulletPrefab, (transform.position + offset), transform.rotation);
			cdTimer = fireCD;
			Debug.Log (transform.forward);
		}
	}
}
