using UnityEngine;
using System.Collections;

public class AnimatorMethods : MonoBehaviour {

    public Rigidbody rb;
    public Collider parentCollider;
    public NewControllertest controller;
    private Animator myAnimator;
	// Use this for initialization
	void Start ()
    {
        //this.rb = this.transform.root.gameObject.GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
	}
	
    public void EnableG()
    {
        Debug.Log("gg1");
        this.rb.useGravity = true;
        this.rb.constraints = RigidbodyConstraints.None;
        //if (!controller.isSuccess)
        //{
        //    //parentCollider.isTrigger = false;
        //    //Invoke("reset", 1.5f);
        //    //myAnimator.enabled = false;
        //}
        //else
        //{
        //    this.rb.constraints = RigidbodyConstraints.FreezeAll;
        //    controller.isSuccess = false;
        //}
    }

    public void DisableG()
    {
        this.rb.useGravity = false;
        //this.rb.constraints = RigidbodyConstraints.None;

        //parentCollider.isTrigger = true;
    }

    void reset()
    {
        this.rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
