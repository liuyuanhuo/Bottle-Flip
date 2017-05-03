using UnityEngine;
using System.Collections;

public class PositionFixer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3(0, 0, 0.0587f);
    }
}
