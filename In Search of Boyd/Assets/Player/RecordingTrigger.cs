using UnityEngine;
using System;
using System.Collections;

public class RecordingTrigger : MonoBehaviour {

	public RecordingInfo recorder;
	public GameObject recorderObject;
	public GameObject playerObject;
	public Player playerScript;
	public string recordingNumber;
	public GameObject ghost;

	// Use this for initialization
	void Start () {
		playerScript = playerObject.GetComponent<Player> ();
		recorder = recorderObject.GetComponent<RecordingInfo> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		if (playerScript.isRecording == false) 
		{
			ghost.SetActive(false);
			playerScript.currentlySelectedArray = recordingNumber; //Tells the player which array it should write to.
			playerScript.isRecording = true;
			playerObject.transform.position = ghost.transform.position;
			playerScript.nextPosition = playerObject.transform.position;
			playerScript.currentPosition = playerObject.transform.position;

			switch (recordingNumber) //Tells which array within RecordingInfo this trigger will be associated with
			{
			case "recording 1":
				Array.Clear(recorder.recording1,0,1000); //Clears every movement within the RecordingInfo array associated with this trigger.
				break;
			case "recording 2":
				Array.Clear(recorder.recording2,0,1000);
				break;
			case "recording 3":
				Array.Clear(recorder.recording3,0,1000);
				break;
			default:
				Debug.Log("No recordings found");
				break;
			}
		}
	}
}
