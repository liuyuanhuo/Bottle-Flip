using UnityEngine;
using System.Collections;

public class NewControllertest : MonoBehaviour
{
    [SerializeField]
    private GameObject Target;
    public Rigidbody rb;
    public float force;
    public float speed=5.0f;

    public float Yoffset = 2.0f;

    public Animator anim;

    public bool isSuccess = false;

	// Use this for initialization
	void Start ()
    {
        //this.anim = this.GetComponentInChildren<Animator>();
	}
    
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            //this.rb.constraints = RigidbodyConstraints.FreezeRotation;
            this.rb.constraints = RigidbodyConstraints.FreezePositionY;
        }
        if (Input.GetMouseButton(0))
        {
            force += speed * Time.deltaTime;
        }

        if (this.rb.velocity.y > 0)
        {
            Debug.Log("Going Up");
        }

        if (this.rb.velocity.y < 0)
        {
            Debug.Log("Going Down");
        }

        if (Input.GetMouseButtonUp(0))
        {
            this.rb.constraints = RigidbodyConstraints.FreezeRotation;
            this.anim.enabled = true;
            this.anim.SetTrigger("Jump");
            Vector3 desired = this.Target.transform.position - this.transform.position;
            AddForce(force, desired);
            force = 0;
        }
    }

    public void AssignTarget(GameObject G)
    {
        this.Target = G;
    }

    public void AddForce(float Force, Vector3 D)
    {
        Vector3 dir = this.Target.transform.position - this.transform.position;
        dir = new Vector3(dir.x, dir.y + this.Yoffset, dir.z);
        rb.AddForceAtPosition(dir * Force, Vector3.zero, ForceMode.Force);
        //this.rb.AddForce(dir * Force, ForceMode.Force);

        //float TargetAngle = Vector3.Dot(this.t.Target.transform.position, this.transform.position);
        //this.targetDirection = dir;
        //float dotProduct = Vector3.Dot(D, dir);
        //float angle = Vector3.Angle(D, dir);
        //angle = angle - 90;
        //this.Started = true;
        //if (TargetAngle > 20)
        //{
        //if (this.Check)
        //this.rb.AddForceAtPosition(dir * Force, Vector3.zero, ForceMode.Acceleration);

        //    else
        //        this.rb.AddForce(D * Force, ForceMode.Acceleration);
        //}

        //else if (TargetAngle < 20)
        //{
        //    if (this.Check)
        //        this.rb.AddForceAtPosition(dir * Force, Vector3.zero, ForceMode.Acceleration);

        //    else
        //        this.rb.AddForce(D * Force, ForceMode.Acceleration);
        //}
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag=="Target")
        {
            Debug.Log("ff");
            isSuccess = true;
            this.rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
