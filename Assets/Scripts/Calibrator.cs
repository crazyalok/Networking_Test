using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calibrator : MonoBehaviour {
	//public static Quaternion angle;
	public static Vector3 angle;
	public static Vector3 position ;
	public static Transform transform;
	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
		//transform.eulerAngles = angle;
		//transform.position = position;
	}
}
