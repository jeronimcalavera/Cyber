using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MyDialogueSystem : MonoBehaviour 
{
	public bool debugMode = false;
	public bool ShowGUI = false; 
	public bool checkKeyDown = false;
    public GUIStyle style = null;
    public string[] answers;
    public string[] questions;

    
  


	void OnTriggerEnter (Collider other) //enter the trigger
	{			
				if ((other.gameObject.name == "Collider_player"))
				{
					ShowGUI = true;
					 Debug.Log ("Collider - check");
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
	   		 Debug.Log ("Key down - check");
			}
		  }
		if (ShowGUI == false) {
			checkKeyDown = false;		
		}
	   }


	void OnGUI()//GUI box
		{
            GUILayout.BeginArea(new Rect(10, 50, 150, 150));
		if (debugMode || Application.isPlaying){
            if (ShowGUI == true && checkKeyDown == true) 
		 {

             GUILayout.Label(questions[0]);


                }
			}
        }
}
	
