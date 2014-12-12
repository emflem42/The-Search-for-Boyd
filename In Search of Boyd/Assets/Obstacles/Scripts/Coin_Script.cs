using UnityEngine;
using System.Collections;

public class Coin_Script : MonoBehaviour 
{
	private ScoreScript scoreScript;

	// Use this for initialization
	void Start () 
	{
		scoreScript = GameObject.Find ("score").GetComponent<ScoreScript>();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("THIS COIN IS DESTROYED");
		this.gameObject.SetActive(false);
			

		scoreScript.scoreCounter+=10;
	}
}
