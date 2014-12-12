using UnityEngine;
using System.Collections;

public class PlayRecording : MonoBehaviour {

	/* !!!!!!!!!!!!!!!!!---------IMPORTANT---------!!!!!!!!!!!!!!!!!!!!
	 * --------------------------------------------------------------
	 * This script does not work yet.
	 * --------------------------------------------------------------
	 * */

	public RecordingInfo recorder;
	public GameObject recorderObject;
	public GameObject ghostObject;
	public Ghost ghostScript;
	bool isActive = false;
	float playTimer = 0.0f;
	public string recordingNumber;
	string[] recording;
	int counter = 0;


	// Use this for initialization
	void Start () {
		recorder = recorderObject.GetComponent<RecordingInfo> ();
		ghostScript = ghostObject.GetComponent<Ghost> ();
		SetRecording ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playTimer <= 0.4f) 
		{
			playTimer += Time.deltaTime;
		}
		if (recording [counter] == null) 
		{
			isActive = false;
			counter = 0;
			ghostObject.transform.position = ghostScript.initialPosition;
			ghostScript.targetPosition = ghostScript.initialPosition;
		}

		if (isActive && playTimer > 0.4f) 
		{
			ghostObject.SendMessage("Move", recording[counter]);
			playTimer = 0.0f;
			counter++;
		}
		
	}

	void SetRecording()
	{
		switch (recordingNumber) 
		{
				case "recording 1":
						recording = recorder.recording1;
						break;
				case "recording 2":
						recording = recorder.recording2;
						break;
				case "recording 3":
						recording = recorder.recording3;
						break;
				default:
						Debug.Log ("Invalid recording number");
						break;
		}
	}

	void OnMouseDown()
	{
		Debug.Log ("Now Playing");
		isActive = true;
	}
}
