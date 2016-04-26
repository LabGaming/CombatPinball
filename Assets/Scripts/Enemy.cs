using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    

	public float max_health = 100f;
    float curr_health;
	public AudioClip deathClip;
    public GameObject healthBar;
    public GameObject bar;

	private bool isDead;

	// Use this for initialization
	void Start () {
        curr_health = max_health;
		
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion fixedRotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        healthBar.transform.rotation = fixedRotation;
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Ball") {
            decreaseHealth(10);
            
			Debug.Log ("Health: " + curr_health);
		}

		if (curr_health <= 0) {
			Destroy (this.gameObject);
		}
	}

    void decreaseHealth(float amount)
    {
        curr_health -= amount;
        setHealthBar(curr_health / max_health);


    }

    void setHealthBar(float health)
    {
        //
        bar.transform.localScale = new Vector3(health, bar.transform.localScale.y, bar.transform.localScale.z);
    }

}
