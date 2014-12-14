using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	int moveDistance = 1;
	public RecordingInfo recorder; //RecordingInfo script
	public GameObject recorderObject; //RecordingManager game object
	public Vector3 nextPosition;
	public Vector3 currentPosition;
	public Vector3 previousPosition;
	public string currentlySelectedArray;
	public int movementCounter = 0;
	public string[] currentArray;
	public Vector3 recordingStartPosition;
	public bool isRecording = false;
	public float moveDelay = 1.0f;
	public float moveTimer = 0.0f;
	public bool hitObject = false;

	// Use this for initialization
	void Start () {
		recorder = recorderObject.GetComponent<RecordingInfo> ();
		recordingStartPosition = transform.position;
		nextPosition = transform.position; //Set the target position equal to the initial position
		currentPosition = transform.position;
		currentlySelectedArray = "recording 1";
	}
	
	// Update is called once per frame
	void Update () {
		currentArray = setArray (currentlySelectedArray); //Decide which array in RecordingInfo to use
		

		if (isRecording)
		{
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				previousPosition = currentPosition;
				nextPosition = new Vector3 (currentPosition.x - moveDistance, currentPosition.y, currentPosition.z);
				AddMovement (currentArray, movementCounter, "Left");
				movementCounter++;

			}

			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				previousPosition = currentPosition;
				nextPosition = new Vector3 (currentPosition.x + moveDistance, currentPosition.y, currentPosition.z);
				AddMovement (currentArray, movementCounter, "Right");
				movementCounter++;

			}

			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				previousPosition = currentPosition;
				nextPosition = new Vector3 (currentPosition.x, currentPosition.y + moveDistance, currentPosition.z);
				AddMovement (currentArray, movementCounter, "Up");
				movementCounter++;
			}

			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				previousPosition = currentPosition;
				nextPosition = new Vector3 (currentPosition.x, currentPosition.y - moveDistance, currentPosition.z);
				AddMovement (currentArray, movementCounter, "Down");
				movementCounter++;
			}

			transform.position = Vector3.Lerp (transform.position, nextPosition, 0.3f);
			currentPosition = nextPosition;


		}

	}

	void AddMovement(string[] array, int index, string movement)
	{
		array [index] = movement;
	}

	public string[] setArray(string array)//Decides what array within RecordingInfo to use based on the string "currentlySelectedArray"
	{
		switch (array) 
		{
		case "recording 1":
			return recorder.recording1;
		case "recording 2":
			return recorder.recording2;
		case "recording 3":
			return recorder.recording3;
		default:
			return null;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Wall")
		{
			currentPosition = previousPosition;
			nextPosition = previousPosition;
		}
	}
}
