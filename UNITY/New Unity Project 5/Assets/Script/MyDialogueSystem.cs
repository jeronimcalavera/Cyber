using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
public class MyDialogueSystem : MonoBehaviour 
{
	private GameObject Player;
	public MonoBehaviour ASSUMEDIRECTCONTROL;
	public MonoBehaviour Directions;

	//boolean 
	public bool debugMode = false;
	public bool ShowGUI = false;
    public bool CheckKeyDown = false;
    public bool Answer = false;
    public bool fork = false;
    public bool ALine = false;
    public bool BLine = false;
    public bool secondpartOfTheDialogue = false;
	public bool TheEnd = false;

	//GUI+Dialogue Lines
    public GUIStyle style = null;
    string[] Q;
    string[] A;
    string[] B; 

	int index = 0;
    int currentLine = 0;

	public Texture image = null;

	void Awake () {
		
		Player = GameObject.Find ("Player");
		ASSUMEDIRECTCONTROL=Player.GetComponent("ASSUMEDIRECTCONTROL") as MonoBehaviour;
		Directions = Player.GetComponent ("Directions") as MonoBehaviour;

		//JavaScript reference
	}

    void Start()
    {
        //First line of the dialogue
        A = new string[2];
        A[0] = "I am your wife";
        A[1] = "I am your wife and i`ve fucked her";

        //Second line of the dialogue
        B = new string[2];
        B[0] = "...";
        B[1] = "Yes, i think you`d better had";

		//Dialogue starts here
		Q = new string[5];
		Q[0] = "";
		Q[1] = "Hello";
		Q[2] = "I will stay behind to gaze at the sun";
		Q[3] = "The sun is wonderous body, like magnificent father";
		Q[4] = "If only i could be so grossly incadescent";

		
	}
	
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
			ASSUMEDIRECTCONTROL.enabled = false;
			Directions.enabled = false;
            CheckKeyDown = true;


            if (index < 4)
            {
                Answer = true;
                index++;
            }
            else
            {
                Answer = false;
                fork = true;
            }
        }
		//First line ends here


        if (Input.GetKeyDown("return") && secondpartOfTheDialogue == true )

        {
			fork = false; //disable buttons

			if (currentLine <= 1) 
			{
           		currentLine++;
				TheEnd = false;
			}

			if (currentLine >1)
			{
				TheEnd = true;
			}
        }


		if (TheEnd == true) //end of the second part of the dialogue
		{
			ShowGUI = false;
			ALine = false;
			BLine = false;
			ASSUMEDIRECTCONTROL.enabled = true;
			Directions.enabled = true;
		}
		
		
		if (ShowGUI == false) 
		{
            CheckKeyDown = false;
		}
	}
	
	
	void OnGUI(){//GUI box
	
       
		if (debugMode || Application.isPlaying)
	{

            if (ShowGUI == true && CheckKeyDown == true && Answer == true)
			{
              
				GUI.Label(new Rect(100,300,120,120), Q[index], style); //first part of the dialogue
 
			}
            if (ShowGUI == true && CheckKeyDown == true && fork == true)
            {

                if (GUI.Button(new Rect(10, 130, 120, 120), "You`ve fucked my wife")) //First button choosed
                {
                    ALine = true;

                }


                if (GUI.Button(new Rect(10, 350, 120, 120), "oh, ah, i'd better go")) //Second button choosed
                {
                    BLine = true;

                }

            }

                if (BLine == true)
                {
                    GUI.Label(new Rect(10, 130, 120, 120), B[currentLine], style); // B line of the dialogue is activated
                    fork = false;
                    secondpartOfTheDialogue = true;
                }

                if (ALine == true)
                {
                    GUI.Label(new Rect(10, 130, 120, 120), A[currentLine], style); // A line of the dialogue is activated
                    fork = false;
                    secondpartOfTheDialogue = true;
                }

            }
	
			
		}
	}
