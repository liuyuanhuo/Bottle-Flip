using UnityEngine;
using System.Collections;

public class particletime : MonoBehaviour {
	private float tt;
	private bool TimeStart;
	public float stopTime;
	public bool isonClick;
	// Use this for initialization
	void Start () {
	
	}
	void OnEnable(){
		TimeStart=true;
		tt=0;
	}
	// Update is called once per frame
	void Update () {
		if(TimeStart){
			tt+=Time.deltaTime;
		}
		if(tt>=stopTime){
			tt=0;
			if(!isonClick){
			GetComponent<ParticleSystem>().Stop ();
			}
			gameObject.SetActive(false);
		}
	}
}
