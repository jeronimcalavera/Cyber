using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MyDialogueSystem : MonoBehaviour 
{
	public bool debugMode = false;
	public Texture2D Image = null;
	public Rect position = new Rect (10, 10, 150, 150);
	public bool ShowGUI = false; 
	public bool checkKeyDown = false;

	void OnTriggerEnter (Collider other) //enter the trigger
	{			
				if ((other.gameObject.name == "Collider_player"))
				{
					ShowGUI = true;
					 Debug.Log ("no way");
		  }
		}
	void OnTriggerExit (Collider other) //exit the trigger
	{
		if ((other.gameObject.name == "Collider_player"))
		{
			ShowGUI = false;
			 Debug.Log ("ah, go away");
		}
	}

	void Update (){ //press enter to execute
		if (Input.GetKey("return") && ShowGUI == true)
		    {
			if (!checkKeyDown){
		    checkKeyDown = true;
	   		 Debug.Log ("BUTTSEX");
			}
		  }
		if (ShowGUI == false) {
			checkKeyDown = false;		
		}
	   }


	void OnGUI()//GUI box
		{
		if (debugMode || Application.isPlaying){
		if (ShowGUI == true && checkKeyDown==true) 
		 {
				GUI.Box (position, Image);

			 }
			}
		}
	}