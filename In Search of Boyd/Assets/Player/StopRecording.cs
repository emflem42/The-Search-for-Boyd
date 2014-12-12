using UnityEngine;
using System.Collections;

public class StopRecording : MonoBehaviour {

	//This script is used to tell the player to stop recording their movements to the RecordingInfo arrays and to reset the player and all ghosts to their
	//starting positions.

	public GameObject playerObject;
	public Player playerScript;
	public GameObject [] ghostObjects = new GameObject[3];
	public Ghost [] ghostScripts = new Ghost[3];

	// Use this for initialization
	void Start () {
		playerScript = playerObject.GetComponent<Player> ();
		//Since there is only one stop button, it needs an array of all the ghost objects in the scene. These are set by hand, but the ghost scripts are set here.
		for(int i = 0; i < 3; i++)
		{
			ghostScripts[i] = ghostObjects[i].GetComponent<Ghost>();
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		//Set the player back to their start position
		playerScript.movementCounter = 0;
		playerObject.transform.position = playerScript.recordingStartPosition;
		playerScript.isRecording = false;
		playerScript.currentlySelectedArray = null;

		//Set the ghosts back to their starting position
		for (int j = 0; j < 3; j++)
		{
			ghostScripts[j].targetPosition = ghostScripts[j].initialPosition;
			ghostObjects[j].transform.position = ghostScripts[j].initialPosition;
		}
	}
}
