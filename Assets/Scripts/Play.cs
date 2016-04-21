using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Play : MonoBehaviour {
	public Text highScore;
	// Use this for initialization
	void Start () {
		highScore.text= Main.highScore.ToString ();
		Debug.Log (highScore.text);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void test ()
	{
		Application.LoadLevel ("Scene1");
	}
	public void quit()
	{
		Application.Quit();
	}
}
