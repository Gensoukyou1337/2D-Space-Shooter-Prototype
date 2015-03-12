using UnityEngine;
using System.Collections;

public class ChaseCamera : MonoBehaviour {

	public Transform camFocusObj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (camFocusObj != null)
		{
			Vector3 targetPos = camFocusObj.position;
			targetPos.z = transform.position.z;
			//Vector3.Lerp?
			transform.position = targetPos;
		}
	}
}
