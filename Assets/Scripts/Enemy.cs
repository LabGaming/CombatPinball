using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health = 100f;
	public AudioClip deathClip;

	private bool isDead;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Ball") {
			health -= 50;
			Debug.Log ("Health: " + health);
		}

		if (health <= 0) {
			Destroy (this.gameObject);
		}
	}
}
