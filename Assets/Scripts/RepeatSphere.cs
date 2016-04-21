using UnityEngine;
using System.Collections;

public class RepeatSphere : MonoBehaviour {
	// Use this for initialization
	int alpha=0;
	public Transform explosion;
	public Material[] materials;
 

	void Start () {
		//set material according to instance id.
		alpha = (-1) * GetInstanceID () % 27;
		GetComponent<Renderer> ().material = materials [alpha];
	}

	// Update is called once per frame
	void Update () {
		//if alpha goes out of visibility
		if (this.transform.position.y < -5) {
			Destroy (this.gameObject);
			Main.misses++;
		}
	} 
}



