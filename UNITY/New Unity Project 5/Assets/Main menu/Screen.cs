using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]

public class Screen : MonoBehaviour {

	public MovieTexture ScreenVideo;

	void Start () {
	
		renderer.material.mainTexture = ScreenVideo as MovieTexture;
		ScreenVideo.Play ();
	}
	
}
