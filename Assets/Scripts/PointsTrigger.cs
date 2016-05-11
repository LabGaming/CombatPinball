using UnityEngine;
using System.Collections;

public class PointsTrigger : MonoBehaviour {

	PointsGenerator script;
	// Use this for initialization
	void Start () {
		script = FindObjectOfType<PointsGenerator> ();
	}
	
	// Update is called once per frame
	void Update () {
		/* only for test points position
		  if (Input.GetButtonDown("Pull")) {
			int number = Random.Range(-10,10);
			string numbreString = number.ToString();
			script.PointDesing (this.transform , numbreString);
		}*/
	}

}
