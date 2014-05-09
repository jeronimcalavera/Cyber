using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MyDialogueSystem : MonoBehaviour 
{
	public bool debugMode = false;
	public bool ShowGUI = false;
    public bool CheckKeyDown = false;
    public GUIStyle style = null;
    string[] Q;
	int index = 0;

	
	
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
            index = 0;
			Debug.Log ("ah, go away");
		}
	}
	
	void Update (){ //press enter to execute
		if (Input.GetKeyDown("return") && ShowGUI == true)
		{
            index++;
            CheckKeyDown = true;

		}
		if (ShowGUI == false) {
            CheckKeyDown = false;		
		}
	}
	
	
	void OnGUI()//GUI box
	{
        Q = new string[5];
        Q[0] = "EMPTY";
        Q[1] = "Hello";
        Q[2] = "You fucked my wife";
        Q[3] = "I AM your wife";
        Q[4] = "I am your wife and i fucked her";

		if (debugMode || Application.isPlaying){
            if (ShowGUI == true && CheckKeyDown == true)
			{
				GUI.Label(new Rect(10,10,120,120), Q[index]);
				
			}
			
		}
	}
}