using UnityEngine;
using System.Collections;

public class BulletDestroy : MonoBehaviour {

	public float lifeTimer;

	// Update is called once per frame
	void Update ()
	{
		lifeTimer -= Time.deltaTime;
		if (lifeTimer < 0)
		{
			Destroy (gameObject);
		}
	}
}
