using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreMarker : MonoBehaviour {
	public static int score;
	public Text text;

	// Use this for initialization
	void Start ()
	{
		text = GetComponent<Text> ();
		score = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		text.text = "Score = " + score;
	}
}
