using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {
    public AudioSource gameOver;
    // Use this for initialization
    void OnEnable()
    {
        if (!gameOver.isPlaying)
        {
            gameOver.Play();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
