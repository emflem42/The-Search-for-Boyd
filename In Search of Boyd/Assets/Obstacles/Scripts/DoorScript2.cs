using UnityEngine;
using System.Collections;

public class DoorScript2 : MonoBehaviour {
	
	public GameObject myTrigger;
	public Trigger triggerScript;
	public Vector2 position;
	public Vector2 targetPosition;

	// Use this for initialization
	void Start () {
		triggerScript = myTrigger.GetComponent<Trigger> ();
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		openDoorRight ();
	}

	// run this code if you want the door to move right/left - currently updating to do so 
	public void openDoorRight()
	{
		switch(triggerScript.on)
		{
		case true: 
			targetPosition = new Vector2(transform.position.x + 1f, transform.position.y);
			transform.position = Vector2.Lerp(position,targetPosition, .4f);
			break;

		case false:
			targetPosition = new Vector2(transform.position.x + -1f, transform.position.y);
			transform.position = Vector2.Lerp(position, targetPosition , .4f);
			break; 
		}
	}

	//run this code in update if you want the door to move up and down instead
	public void openDoorUp()
	{
		switch (triggerScript.on)
		{
		case true:
			targetPosition = new Vector2(transform.position.x, transform.position.y + 1f);
			transform.position = Vector2.Lerp(position,targetPosition, .4f);
			break;
		case false:
			if (transform.position.y >position.y - 1.5f)
			{
				Debug.Log (position.y + " vs " + transform.position.y);
			targetPosition = new Vector2(transform.position.x, transform.position.y + -0.25f);
			transform.position = Vector2.Lerp(transform.position,targetPosition, .4f);
			}
			break;
		}
	}
}
