using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour 
{
	//adjust inventoryObject variable in ItemScript

	private ItemScript itemScript1;
	private ItemScript itemScript2;
	private ItemScript itemScript3;
	private ItemScript itemScript4;
	private ItemScript itemScript5;
	//private bool inventoryToggle = true; 
	private Rect inventoryWindowRect = new Rect(0, 225, 810, 100);
	//new GameObject[] inventoryArray = new GameObject[10];
	//int arrayNumber = 0;
	// Use this for initialization

	void Start () 
	{
		itemScript1 = GameObject.Find ("Key").GetComponent<ItemScript>();
		itemScript2 = GameObject.Find ("ID Card").GetComponent<ItemScript>();
		itemScript3 = GameObject.Find ("Book").GetComponent<ItemScript>();
		itemScript4 = GameObject.Find ("Paper").GetComponent<ItemScript>();
		itemScript5 = GameObject.Find ("Money").GetComponent<ItemScript>();
		//inventoryArray [1] = null;
	}
	
	// Update is called once per frame
	void Update () 
	{
		OnGUI();
	}

	void OnGUI()
	{

			inventoryWindowRect = GUI.Window (0, inventoryWindowRect, inventoryWindowMethod, "Inventory");
		
	}

	void inventoryWindowMethod (int windowID)
	{
			
		GUILayout.BeginArea(new Rect(50,30,700,100));
		GUILayout.BeginHorizontal ();
		GUILayout.Box (itemScript1.inventoryObject, GUILayout.Height (50));
		GUILayout.Box (itemScript2.inventoryObject, GUILayout.Height (50));
		GUILayout.Box (itemScript3.inventoryObject, GUILayout.Height (50));
		GUILayout.Box (itemScript4.inventoryObject, GUILayout.Height (50));
		GUILayout.Box (itemScript5.inventoryObject, GUILayout.Height (50));
		GUILayout.EndHorizontal ();
		GUILayout.EndArea ();



			/*Debug.Log("Iterating");
			if(itemScript.itemArray[i].activeInHierarchy == false);
			{
				 //this.gameobject.SpriteRenderer.Sprite;

			}*/

		
	}


	/*void ItemActive()
	{
		foreach (GameObject item in itemScript.itemArray) 
		{
			
			if(item.activeInHierarchy == false)
			{
				inventoryArray[arrayNumber] = item;
				arrayNumber++;
			}
		}

	}*/
	//display itemScript.itemArray[i].

}