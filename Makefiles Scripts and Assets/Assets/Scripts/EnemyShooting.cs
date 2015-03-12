using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {
	public float fireCD = 1f;
	private float cdTimer = 0;
	public GameObject bulletPrefab;
	
	void Update ()
	{
		cdTimer -= Time.deltaTime;
		if (cdTimer <= 0)
		{
			//shoot command
			Vector3 offset = transform.rotation * new Vector3(0, 0.72f, 0);
			Instantiate (bulletPrefab, (transform.position + offset), transform.rotation);
			cdTimer = fireCD;
			Debug.Log (transform.forward);
		}
	}
}
