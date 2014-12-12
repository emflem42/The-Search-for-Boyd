using UnityEngine;
using System.Collections;
[ExecuteInEditMode]

public class ScoreScript : MonoBehaviour 
{

	public int scoreCounter = 0;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		guiText.text = "Score: " + scoreCounter;
	}
}
