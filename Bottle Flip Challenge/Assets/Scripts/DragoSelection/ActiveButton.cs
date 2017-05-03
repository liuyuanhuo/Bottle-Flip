using UnityEngine;
using System.Collections;

public class ActiveButton : MonoBehaviour {
    public GameObject next, previous;
	// Use this for initialization
	void Start () {
	
	}
	
    public void activeBtn()
    {
        next.SetActive(true);
        previous.SetActive(true);
    }
    public void deActiveBtn()
    {
        next.SetActive(false);
        previous.SetActive(false);
    }
}
