using UnityEngine;
using System.Collections;
using System;

public enum TargetMode
{
    
    DynamicTarget,
    StaticTarget
}

public class TargetTest : MonoBehaviour {

    public GameObject Target;
    public GameManager manager;
    public GameObject Player;
    public BottleTest bottle;
    public NewControllertest contr;
    private float distance;

    public TargetMode targetMod;

    public float Distance
    {
        get
        {
            return this.distance;
        }
    }

	// Use this for initialization
	void Start () 
    {
        this.bottle = this.transform.root.gameObject.GetComponent<BottleTest>();
       // this.contr = this.transform.root.gameObject.GetComponent<NewControllertest>();
        this.Player = this.transform.root.gameObject;
        this.manager = GameManager.GetInstance();   
	}

    void OnTriggerEnter(Collider col)
    {
        if (this.targetMod.Equals(TargetMode.DynamicTarget))
        {
            if (col.gameObject.tag.Equals("Target"))
            {
                if (col.gameObject.Equals(this.Target))
                {
                    return;
                }
                this.Target = col.transform.root.gameObject;
                this.bottle.AssignTarget(this.Target);
                this.distance = Vector3.Distance(this.Target.transform.position, this.Player.transform.position);
                //  this.contr.AssignTarget(col.gameObject);
            }
        }
    }
}
