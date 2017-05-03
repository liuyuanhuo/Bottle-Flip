using UnityEngine;
using System.Collections;

public enum BottleStates
{
    Alive,
    Dead
}

public enum GameplayMode
{
    Runner,
    StaticDump
}

public class BottleTest : MonoBehaviour
{
    public BottleStates bottleState;
    [SerializeField]
    private GameObject Target;
    public Rigidbody rb;
    public float force;
    public float speed = 5.0f;

    public float Yoffset = 2.0f;

    public bool Rotate;

    public GameManager manager;

    public float RotationSpeed = 30f;

    public static bool AllowInput;

    public bool RotateUp;
    public bool RotateDown;

    public GameObject ActiveBottle;

    public Animator anim;

    public GameplayMode mode = GameplayMode.Runner;

    public ActiveBottle activeBottle;

    public GameObject Bottle;

    public Vector3 OriginalScale;

    public GameObject PlatForm;
    public Vector3 PlatformOriginalScale;

    public float ScaleOffset = 0.3f;

    public string CurrentPlatformName = "None";

    public Vector3 desired;

    public float CoveredDistance;

    public GameObject Particle;

    public float HurdleScaleOffset;

    public float BottleScaleOffset;

    public AudioSource aud;

    public bool OnBasket;

    public GameObject Road;

    public float HurdleSqueezeLimit = 0.4f;

    public float RightOffset = 0.2f;

    void Awake()
    {
        AllowInput = false;
         Invoke("EnableInput", 0.8f);
        if (this.Particle)
        {
            this.Particle.SetActive(false);
        }
        this.CoveredDistance = 0.0f;
        this.rb = this.GetComponent<Rigidbody>();
        this.manager = GameObject.FindObjectOfType<GameManager>();
        this.anim = this.ActiveBottle.GetComponent<Animator>();
        this.activeBottle = this.GetComponentInChildren<ActiveBottle>();
        Invoke("AssignActiveBottle", 0.01f);
    }

    public void EnableInput()
    {
         AllowInput = true;
    }

    public void AssignActiveBottle()
    {
        this.Bottle = this.activeBottle.Bottle;
        this.OriginalScale = this.Bottle.transform.localScale;
    }

    public void AssignTarget(GameObject g)
    {
        this.Target = g;
    }

    public void RD()
    {
        this.RotateDown = true;
      //  this.rb.isKinematic = true;
        CancelInvoke("RD");
    }

    public void MakeItNormal()
    {
        this.rb.isKinematic = false;
        CancelInvoke("MakeItNormal");
    }

    public void RestoreScale()
    {
        this.Bottle.transform.localScale = this.OriginalScale;
        this.PlatForm.transform.localScale = this.PlatformOriginalScale;
        CancelInvoke("RestoreScale");
    }

    public void ResetName()
    {
        this.CurrentPlatformName = "None";
        CancelInvoke("ResetName");
    }

    // Update is called once per frame
    void Update()
    {
        if (AllowInput)
        {
            if (Input.GetMouseButton(0))
            {
                this.Particle.SetActive(true);
                this.rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                this.transform.rotation = Quaternion.Euler(Vector3.zero);
                Physics.gravity = new Vector3(0, -23.81f, 0);
           //     Debug.Log(Physics.gravity.y + "When applying force");
                if (force < 500f)
                {
                    force += speed * Time.deltaTime;
                }
                Vector3 Scale = this.Bottle.transform.localScale;
                Vector3 PScale = this.PlatForm.transform.localScale;
                if (PScale.y < this.HurdleSqueezeLimit)
                {
                    return;
                }
                this.Bottle.transform.localScale = new Vector3(Scale.x, Scale.y - this.BottleScaleOffset, Scale.z);
                this.PlatForm.transform.localScale = new Vector3(PScale.x, PScale.y - this.HurdleScaleOffset, PScale.z);
            }

            if (Input.GetMouseButtonUp(0))
            {
                Invoke("ResetName", 0.5f);
                if (this.PlatForm)
                {
                    if (this.PlatForm.GetComponent<HurdleSpawner>())
                    {
                        this.PlatForm.GetComponent<HurdleSpawner>().MarkVisible();
                    }
                }
                this.desired = this.Target.transform.position - this.transform.position;
                AddForce(force, desired);
                Invoke("Test", 0.1f);   ////////////////////////////////////////////////////////Test Line
                this.Particle.SetActive(false);
                //Invoke("RestoreScale", 0.12f);
                this.RestoreScale();
                Invoke("RD", 0.1f);
                AllowInput = false;
                // Invoke("ApplyForce", 0.03f);
                force = 40;
                this.anim.SetTrigger("FlipUp");
                this.manager.CloseTutorial();
                //this
                //this.AllowInput = false;
                //   this.RotateUp = true;
                this.aud.PlayOneShot(this.aud.clip);
            }
        }

        if (this.rb.velocity.y < 0 & this.RotateDown)
        {
            Physics.gravity = new Vector3(0, -45, 0);
    //        Debug.Log(Physics.gravity.y + "When falling down");
            this.anim.SetTrigger("FlipDown");
            this.RotateDown = false;
            Debug.Log("Is Not Missing");

     //       Invoke("MakeItNormal", 0.2f);
            //Debug.Log("Going Down");
            //  this.FlipDown();
        }
        //if (this.Rotate)
        //{
        //    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(Vector3.zero), 15f*Time.deltaTime);
        //   // Invoke("ResetRotate");
        //}
    }

    void ApplyForce()
    {
        AddForce(force, this.desired);
        force = 0;
        this.RotateUp = true;
        this.anim.SetTrigger("FlipUp");
    }

    void ResetRotate()
    {
        this.Rotate = false;
    }

    public void Test()
    {
        if (this.PlatForm.GetComponent<HurdleSpawner>())
            this.PlatForm.GetComponent<HurdleSpawner>().MakeITTrigger();
        CancelInvoke("Test");
    }

    public void FlipUp()
    {
        this.Flip(180);
    }

    public void FlipDown()
    {
        this.Flip(358);
        //      Debug.Log(Quaternion.Angle(this.transform.rotation, Quaternion.Euler(358, 0, 0)));
        //if (this.transform.rotation.x < 0)
        //{
        //    return;
        //}
        //Quaternion Q = this.transform.rotation;
        //this.transform.rotation = Quaternion.Slerp(Q, Quaternion.Euler(Q.x + 120f, 0, 0), this.RotationSpeed *Time.deltaTime);
    }

    public void Flip(float RotVal)
    {
        this.ActiveBottle.transform.rotation = Quaternion.Slerp(this.ActiveBottle.transform.rotation, Quaternion.Euler(RotVal, 0, 0), this.RotationSpeed * Time.deltaTime);
    }

    public float ExtraForce;


    public void AddForce(float Force, Vector3 D)
    {
        Vector3 dir = this.Target.transform.position - this.transform.position;
        dir = new Vector3(dir.x-this.RightOffset, dir.y + this.Yoffset, dir.z*this.ExtraForce);
        this.rb.AddForceAtPosition(dir * Force, Vector3.zero, ForceMode.Acceleration);
    }

    public float RestoreWait = 1.0f;

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Ungli " + col.gameObject.name);
        Physics.gravity = new Vector3(0, -9.81f, 0);
        this.rb.constraints = RigidbodyConstraints.None;
        this.RotateDown = false;
        this.RotateUp = false;
        if (col.gameObject.tag.Equals("Environment"))
        {
            this.OnBasket = false;
            if (this.mode.Equals(GameplayMode.StaticDump))
            {
                Invoke("Restore", this.RestoreWait);
                return;
            }
            this.bottleState = BottleStates.Dead;
            this.GameOver();
            this.enabled = false;
        }
        else if (col.gameObject.tag.Equals("Target"))
        {
            Invoke("MoveEnvironment", 0.5f);
            if (col.gameObject.name != "SpawnPoint")
            {
                //this.rb.velocity = Vector3.zero;
            }
            this.OnBasket = false;
            this.PlatForm = col.transform.root.gameObject;
            //if (this.PlatForm.GetComponent<HurdleSpawner>())
            //{
            //    this.PlatForm.GetComponent<HurdleSpawner>().ExtendCollider();
            //}
            this.PlatformOriginalScale = new Vector3(1, 1, 1);
            if (this.PlatForm.gameObject.name != this.CurrentPlatformName)
            {
                //if (col.gameObject.GetComponentInChildren<TargetTest>())
                //{
                this.CoveredDistance += this.GetComponentInChildren<TargetTest>().Distance;
                if (col.gameObject.name != "SpawnPoint")
                Invoke("RegisterFlip", 0.7f);
                //}
                this.manager.SpawnNextHurdle(this.PlatForm.transform.position, Quaternion.Euler(Vector3.zero));
                Debug.Log("Hurdle Spawned");
                this.CurrentPlatformName = col.gameObject.name;
                if (this.PlatForm.GetComponentInChildren<UnityEngine.UI.Text>())
                {
                    this.PlatForm.GetComponentInChildren<UnityEngine.UI.Text>().transform.parent.gameObject.SetActive(false);
                }
            }
            Invoke("InputOn", 0.4f);
        }

        else if (col.gameObject.tag.Equals("Basket"))
        {
            PrefsManager.AddToCurrentBottleDumps();
            col.gameObject.GetComponent<SphereCollider>().enabled = false;
            PrefsManager.AddToTotalSuccessFullDumps();
            this.OnBasket = false;
            Debug.Log("In Basket");
            this.manager.AddCoins();
            Invoke("Restore", this.RestoreWait);
        }
        else if (col.gameObject.tag.Equals("BasketMain"))
        {
            this.OnBasket = true;
            Invoke("Check", this.RestoreWait);
        }
        //else if (col.gameObject.tag != "Finish" && col.gameObject.tag!="Target" && col.gameObject.tag!="Environment")
        //{
        //    if (this.transform.eulerAngles.x > -2 && this.transform.eulerAngles.x < 2)
        //    {
        //        //this.rb.AddTorque(this.transform.forward* 500f);
        //        AddForce(40, desired);
        //        Debug.Log("INto Else Case");
        //        //Invoke("GameOver", 0.5f);
        //    }
        //}
        //   Invoke("TestAllign", 0.3f);
    }

    public void Check()
    {
        if (this.OnBasket)
        {
            this.Restore();
        }
    }

    void MoveEnvironment()
    {
    //    Debug.Log("Called");
        this.Road.GetComponent<EnvironmentMover>().MoveBy(3f);
        CancelInvoke("MoveEnvironment");
    }

    public void RegisterFlip()
    {
        PrefsManager.AddToTotalSuccessFullFlips();
        PrefsManager.AddToCurrentBottleFlipCount();
     //   Debug.Log(PrefsManager.GetCurrentBottleFlipsCount());
        //  Debug.Log(PrefsManager.GetTotalSuccessFullFlips().ToString());
    }

    public void Restore()
    {
       // this.PlatForm.GetComponent<CoinProbability>().CheckAndDecide();
        this.manager.RandomizeBaskePosition();
        this.manager.RestoreToLastPosition();
        this.PlatForm.transform.localScale = new Vector3(1, 1, 1);
       // this.PlatForm.GetComponent<SpawnPoint>().Randomize();
      //  this.rb.velocity = Vector3.zero;
         AllowInput = true;
        //this.PlatForm.transform.lossyScale = new Vector3(1, 1, 1);
    }

    void TestAllign()
    {
        if (this.transform.eulerAngles.x < -2 | this.transform.eulerAngles.x > 2)
        {
            Debug.Log("alli");
            //      Invoke("GameOver", 0.5f);
        }
    }

   public void GameOver()
    {
        this.manager.GameOver();
     //   this.gameObject.SetActive(false);
        CancelInvoke("RegisterFlip");
        switch (this.mode)
        {
            case GameplayMode.Runner:
                if (PrefsManager.GetCurrentBottleFlipsCount() > PrefsManager.GetBestBottleFlipCount())
                {
                    PrefsManager.SetBestBottleFlipCount(PrefsManager.GetCurrentBottleFlipsCount());
                }
                break;

            case GameplayMode.StaticDump:
                if (PrefsManager.GetCurrentBottleDumps() > PrefsManager.GetBestBottleDumpCount())
                {
                    PrefsManager.SetBestBottleDumpCount(PrefsManager.GetCurrentBottleDumps());

                    Social.ReportScore((int)(PrefsManager.GetBestBottleDumpCount()), "CgkIkO25l88cEAIQAQ", (bool success) => {
                    });
                }
                this.enabled = false;
                Debug.Log("gaaaame");
                break;
        }
    }



    void Falsify()
    {
        HurdleSpawner.CanCalculate = false;
    }

    void InputOn()
    {
         AllowInput = true;
    }

}
