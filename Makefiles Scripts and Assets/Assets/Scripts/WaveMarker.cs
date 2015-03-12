using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveMarker : MonoBehaviour {
	private static int waveNum;
	public static Text text;

	// Use this for initialization
	void Start ()
	{
		text = GetComponent<Text> ();
		waveNum = 1;
		StartCoroutine ("WaveIncrementCo");
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public IEnumerator WaveIncrementCo()
	{
		text.text = "Wave " + waveNum;
		yield return new WaitForSeconds (2);
		text.text = "";
	}
}
