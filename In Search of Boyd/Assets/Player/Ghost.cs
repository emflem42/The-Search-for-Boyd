using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour {
	public RecordingInfo recorder;
	public GameObject recorderObject;
	public Player playerScript;
	public GameObject playerObject;
	string[] readArray;
	public string ghostRecording;
	public Vector3 nextPosition;
	public Vector3 initialPosition;
	public Vector3 currentPosition;
	public Vector3 previousPosition;
	int moveDistance = 1;
	public bool isPlaying = false;

	// Use this for initialization
	void Start () {
		recorder = recorderObject.GetComponent<RecordingInfo> ();
		playerScript = playerObject.GetComponent<Player> ();
		setRecording ();
		nextPosition = transform.position;
		initialPosition = transform.position;
		currentPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerScript.isRecording && readArray[playerScript.movementCounter] + 1 != null) 
		{
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				Move(readArray[playerScript.movementCounter - 1]);
			}

			else if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				Move(readArray[playerScript.movementCounter - 1]);
			}

			else if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				Move(readArray[playerScript.movementCounter - 1]);
			}

			else if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				Move(readArray[playerScript.movementCounter - 1]);
			}

			transform.position = Vector3.Lerp (transform.position, nextPosition, 0.3f);
		}

		if (isPlaying) 
		{
			transform.position = Vector3.Lerp(transform.position, nextPosition, 0.6f);
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
			previousPosition = currentPosition;
			nextPosition = new Vector3 (currentPosition.x - moveDistance, currentPosition.y, currentPosition.z);
			currentPosition = nextPosition;
			break;
		case "Right":
			previousPosition = currentPosition;
			nextPosition = new Vector3 (currentPosition.x + moveDistance, currentPosition.y, currentPosition.z);
			currentPosition = nextPosition;
			break;
		case "Up":
			previousPosition = currentPosition;
			nextPosition = new Vector3 (currentPosition.x, currentPosition.y + moveDistance, currentPosition.z);
			currentPosition = nextPosition;
			break;
		case "Down":
			previousPosition = currentPosition;
			nextPosition = new Vector3 (currentPosition.x, currentPosition.y - moveDistance, currentPosition.z);
			currentPosition = nextPosition;
			break;
		default:
			Debug.Log("Could not find array element");
			break;
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.gameObject.tag == "Wall") 
		{
			Debug.Log ("Ghost hit the wall");
			currentPosition = previousPosition;
			nextPosition = previousPosition;
		}
	}
}
