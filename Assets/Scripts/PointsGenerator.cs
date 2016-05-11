using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointsGenerator : MonoBehaviour {

	//private Text shadowText;
	//private Text principalText;
	public GameObject prefabCanvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void PointDesing(Transform positionPoints, string TextPoints){
		GameObject pointTemp = Instantiate(prefabCanvas, positionPoints.position, Quaternion.identity) as GameObject;
		pointTemp.GetComponentsInChildren<Text> ()[0].text = TextPoints;
		pointTemp.GetComponentsInChildren<Text> ()[1].text = TextPoints;
	}
}
