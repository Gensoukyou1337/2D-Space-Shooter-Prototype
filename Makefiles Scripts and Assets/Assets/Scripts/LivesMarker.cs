using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesMarker : MonoBehaviour {
	public static int numLives;

	Text text;

	// Use this for initialization
	void Start ()
	{
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		text.text = "Lives = " + numLives;
	}
}
