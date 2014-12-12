using UnityEngine;
using System.Collections;

public class toLevelSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey(KeyCode.Return))
		{

			Application.LoadLevel (1);

		}

	}
}

// for gender select
// when enter_up application loads "levelSelect

//boy is selected automatically, if right arrow key down girl is selected 