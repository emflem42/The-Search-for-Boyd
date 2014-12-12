using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public bool on = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("COLLISION ENTER");
		on = true;
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log ("COLLISION LOST");
		on = false;
	}
}
