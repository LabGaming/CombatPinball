using UnityEngine;
using System.Collections;

public class Points : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		anim.SetTrigger ("Active");
	}

	public void DestroyThis(){
		Destroy (transform.parent.gameObject);
	}
}
