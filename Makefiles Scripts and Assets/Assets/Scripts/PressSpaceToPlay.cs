using UnityEngine;
using System.Collections;

public class PressSpaceToPlay : MonoBehaviour {

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space))
		{
			Application.LoadLevel (1);
		}
	}
}
