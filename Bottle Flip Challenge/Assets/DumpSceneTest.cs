using UnityEngine;
using System.Collections;

public class DumpSceneTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            //this.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
