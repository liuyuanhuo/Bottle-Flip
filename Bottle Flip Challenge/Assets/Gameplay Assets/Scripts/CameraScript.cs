using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour 
{
    private Vector3 Distance;
    public Transform Player;
	// Use this for initialization
	void Start () 
    {
        this.Distance = this.transform.position - Player.transform.position;
     //   InvokeRepeating("UpdatePosition", 0.000011f, 0.000011f);
	}
	
	// Update is called once per frame
    void LateUpdate()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        this.transform.position = this.Distance + Player.transform.position;
    }

}
