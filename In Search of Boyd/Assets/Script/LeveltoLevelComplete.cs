using UnityEngine;
using System.Collections;

public class LeveltoLevelSelect : MonoBehaviour {

	public LevelBeat beat;
	public int levelID;
	public int levelCompleteID;

	// Use this for initialization
	void Start () {
		beat = GameObject.Find ("LevelBeatObject").GetComponent<LevelBeat> ();
	}
	
	// Update is called once per frame
	void Update () {

		/*if (Input.GetKey(KeyCode.Return))
		{
			if (beat.levelBeat == levelID)
			{
				beat.levelBeat++;
			}
			Application.LoadLevel (1);
		}*/
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (beat.levelBeat == levelID)
		{
			beat.levelBeat++;
		}

		Application.LoadLevel (levelCompleteID); //Make sure this goes to LevelComplete
	}
}
