using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour {
	public RecordingInfo recorder;
	public GameObject recorderObject;
	public Player playerScript;
	public GameObject playerObject;
	string[] readArray;
	public string ghostRecording;
	public Vector3 targetPosition;
	public Vector3 initialPosition;
	int moveDistance = 1;
	public bool isPlaying = false;

	// Use this for initialization
	void Start () {
		recorder = recorderObject.GetComponent<RecordingInfo> ();
		playerScript = playerObject.GetComponent<Player> ();
		setRecording ();
		targetPosition = transform.position;
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerScript.isRecording && readArray[playerScript.movementCounter] + 1 != null) 
		{
			if (Input.GetKeyDown(KeyCode.LeftArrow) && playerScript.moveTimer >= 1.0f)
			{
				Move(readArray[playerScript.movementCounter]);
			}

			else if (Input.GetKeyDown(KeyCode.RightArrow) && playerScript.moveTimer >= 1.0f)
			{
				Move(readArray[playerScript.movementCounter]);
			}

			else if (Input.GetKeyDown(KeyCode.UpArrow) && playerScript.moveTimer >= 1.0f)
			{
				Move(readArray[playerScript.movementCounter]);
			}

			else if (Input.GetKeyDown(KeyCode.DownArrow) && playerScript.moveTimer >= 1.0f)
			{
				Move(readArray[playerScript.movementCounter]);
			}

			transform.position = Vector3.Lerp (transform.position, targetPosition, 0.3f);
		}

		if (isPlaying) 
		{
			transform.position = Vector3.Lerp(transform.position, targetPosition, 0.6f);
		}
	
	}

	void setRecording() //decides one what RecordingInfo array to read from based on the "ghostRecording" variable, which is unique to each ghost
	{
		switch (ghostRecording) 
		{
		case "recording 1":
			readArray = recorder.recording1;
			break;
		case "recording 2":
			readArray = recorder.recording2;
			break;
		case "recording 3":
			readArray = recorder.recording3;
			break;
		default:
			Debug.Log("Invalid recording number");
			break;
		}
	}

	void Move(string input) //Reads an element from an array and moves the Ghost accordingly
	{
		switch (input) 
		{
		case "Left" :
			targetPosition = new Vector3 (transform.position.x - moveDistance, transform.position.y, transform.position.z);
			break;
		case "Right":
			targetPosition = new Vector3 (transform.position.x + moveDistance, transform.position.y, transform.position.z);
			break;
		case "Up":
			targetPosition = new Vector3 (transform.position.x, transform.position.y + moveDistance, transform.position.z);
			break;
		case "Down":
			targetPosition = new Vector3 (transform.position.x, transform.position.y - moveDistance, transform.position.z);
			break;
		default:
			Debug.Log("Could not find array element");
			break;
		}
	}
}
