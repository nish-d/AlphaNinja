using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	public GameObject sphere;
	private Vector3 position;
	public Vector2 throwforce = new Vector2(0, 100);
	bool game=true;
	public static int highScore;
	public static int score;
	public Transform explosion;
	private int i=0;
	private Vector3 followPos;
	public Transform TouchTrail;
	private RaycastHit2D hit;
	public static int misses;
	public AudioClip explodeSound;
	public AudioClip gameOver;
	private AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;
	float vol;
	// Use this for initialization
	void Start () {
		
		TouchTrail = (Transform)Instantiate(TouchTrail, Vector3.zero, Quaternion.identity); 
		InvokeRepeating("SpawnAlpha", 0.2f, 1);
		misses = 0;
		score = 0;
		source = GetComponent<AudioSource> ();
	}

	// Update is called once per fram
	void Update () {
		//Get mouse position and draw touch trail;
		if (Input.GetMouseButton (0)) {
			followPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			followPos.z = 0;
			TouchTrail.position = followPos;

			hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector3.zero);

			//Destroy candies when hit;

			if(hit.collider != null)
			{
				
				if (hit.collider.CompareTag ("Alpha")) {
					
					//DrawScore(hit.point, 10, Color.green);
					//UpdateScore(10);
					//soundEffects.collectSource.GetComponent<AudioSource>().clip = soundEffects.CollectSFX;
					//soundEffects.collectSource.GetComponent<AudioSource>().Play();
					//DrawCandyFX(hit.point);
					vol = Random.Range (volLowRange, volHighRange);
					source.PlayOneShot(explodeSound,vol);
					Instantiate (explosion, hit.collider.gameObject.transform.position, Quaternion.identity);
					hit.collider.gameObject.SetActive (false);
					Destroy (hit.collider.gameObject);
					score++;
				}	

			}		
		}
		if (misses > 10) {
			source.PlayOneShot (gameOver);
			Application.LoadLevel ("Menu");
			if (score > highScore)
				highScore = score;
			score = 0;
		}

	}

	void SpawnAlpha()
	{	
		if (game) {
			Quaternion rotation = new Quaternion (0, 0, 180, 0);
			position = new Vector3 (Random.Range (-7.0f, 7.0f), -5.0f, 0); 
			GameObject repeatSphere = Instantiate (sphere, position, rotation) as GameObject;
			repeatSphere.GetComponent<Rigidbody2D> ().AddForce (throwforce, ForceMode2D.Impulse);
		}
	}

}
