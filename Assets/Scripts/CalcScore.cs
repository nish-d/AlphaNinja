using UnityEngine;
using System.Collections;

public class CalcScore : MonoBehaviour {
	public TextMesh score;
	public TextMesh misses;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		score.text = Main.score.ToString ();
		misses.text = Main.misses.ToString ();

	}
}
