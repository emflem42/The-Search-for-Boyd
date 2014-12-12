using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	int moveDistance = 1;
	public RecordingInfo recorder; //RecordingInfo script
	public GameObject recorderObject; //RecordingManager game object
	public Vector3 targetPosition;
	public string currentlySelectedArray;
	public int movementCounter = 0;
	public string[] currentArray;
	public Vector3 recordingStartPosition;
	public bool isRecording = false;
	public float moveDelay = 1.0f;
	public float moveTimer = 0.0f;

	// Use this for initialization
	void Start () {
		recorder = recorderObject.GetComponent<RecordingInfo> ();
		recordingStartPosition = transform.position;
		targetPosition = transform.position; //Set the target position equal to the initial position
		currentlySelectedArray = "recording 1";
	}
	
	// Update is called once per frame
	void Update () {
		currentArray = setArray (currentlySelectedArray); //Decide which array in RecordingInfo to use

		if (moveTimer <= 1.1f) 
		{
			Debug.Log(moveTimer);
			moveTimer += Time.deltaTime; //Increase the timer up to 1 second
		}

		if (isRecording)
		{
			if (Input.GetKeyDown (KeyCode.LeftArrow) && moveTimer >= 1.0f) {
				targetPosition = new Vector3 (transform.position.x - moveDistance, transform.position.y, transform.position.z);
				AddMovement (currentArray, movementCounter, "Left");
				movementCounter++;
				moveTimer = 0.0f;
			}

			if (Input.GetKeyDown (KeyCode.RightArrow) && moveTimer >= 1.0f) {
				targetPosition = new Vector3 (transform.position.x + moveDistance, transform.position.y, transform.position.z);
				AddMovement (currentArray, movementCounter, "Right");
				movementCounter++;
				moveTimer = 0.0f;
			}

			if (Input.GetKeyDown (KeyCode.UpArrow) && moveTimer >= 1.0f) {
				targetPosition = new Vector3 (transform.position.x, transform.position.y + moveDistance, transform.position.z);
				AddMovement (currentArray, movementCounter, "Up");
				movementCounter++;
				moveTimer = 0.0f;
			}

			if (Input.GetKeyDown (KeyCode.DownArrow) && moveTimer >= 1.0f) {
				targetPosition = new Vector3 (transform.position.x, transform.position.y - moveDistance, transform.position.z);
				AddMovement (currentArray, movementCounter, "Down");
				movementCounter++;
				moveTimer = 0.0f;
			}

			transform.position = Vector3.Lerp (transform.position, targetPosition, 0.3f);
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
}
