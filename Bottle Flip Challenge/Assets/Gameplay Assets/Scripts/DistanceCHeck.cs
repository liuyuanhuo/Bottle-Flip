using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DistanceCHeck : MonoBehaviour {

    public GameObject g1;
    public GameObject g2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (this.g1&this.g2)
        {
            Debug.Log("DIstance: " + Vector3.Distance(g1.transform.position, g2.transform.position));
        }
	}
}
