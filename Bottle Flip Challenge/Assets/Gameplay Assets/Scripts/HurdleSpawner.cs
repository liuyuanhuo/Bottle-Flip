using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HurdleSpawner : MonoBehaviour 
{
    public int HurdlesChild;
    public GameObject PreviousOne;
    public int IndexOffset = 2;
    public static bool CanCalculate;
    public GameManager manager;
    public Text distanceText;
    public ObjectPool Hurdlepool;
    public BoxCollider Collider;
   // public Vector3 OriginalColliderScale;
    public GameObject P;
    public float ParticleOffTime = 0.3f;

    public bool canLerp;

    public float targetYPosition;

    public float FallSpeed = 20f;

    public GameObject Coin;

    public GameObject ActiveHurdle;

    public bool IsNormalHurdle;

    //public GameObject CollisionObject;


    void Awake()
    {
        this.Collider = this.GetComponent<BoxCollider>();
     //   this.OriginalColliderScale = this.Collider.size;
        this.manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        this.Hurdlepool = GameObject.Find("HurdlesPool").GetComponent<ObjectPool>();
    }

    void Start()
    {
        this.manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        this.CalculateDistance();
    }

    public void CalculateDistance()
    {
        if(this.distanceText)
        this.distanceText.text =((int) Vector3.Distance(this.transform.position, this.manager.Player.transform.position)).ToString() + "m";
    }

    public void ExtendCollider()
    {
    //    this.Collider.size = new Vector3(1.6f, this.OriginalColliderScale.y,1.85f);
    }

    void ShowParticle()
    {
        this.P.SetActive(true);
    }

    void DisableParticle()
    {
        this.P.SetActive(false);
    }

    void Update()
    {
        if (this.canLerp)
        {
            Vector3 V = this.transform.position;
            if (V.y - this.targetYPosition < 0.03f)
            {
                this.canLerp = false;
                this.ShowParticle();
                Invoke("DisableParticle", this.ParticleOffTime);
            }
            Vector3 VT = new Vector3(V.x, this.targetYPosition, V.z);
            this.transform.position = Vector3.Lerp(this.transform.position, VT, this.FallSpeed * Time.deltaTime);
        }
    }

    public bool CanRandomize;

    void OnEnable()
    {

        if (!this.CanRandomize)
        {
            return;
        }
        int x = Random.Range(0, 2);
        switch (x)
        {
            case 0:
                this.Coin.SetActive(false);
                break;
            default:
                this.Coin.SetActive(true);
                this.Coin.transform.localPosition = new Vector3(0, 0.383f, 0);
                break;
        }
        this.canLerp = true;    
        //this.Collider.size = this.OriginalColliderScale;
        this.RestoreScale();
        this.distanceText.transform.parent.gameObject.SetActive(true);
        this.CalculateDistance();
        this.GetComponent<MeshRenderer>().enabled = false;
        this.HurdlesChild = this.transform.childCount;
        if (this.PreviousOne)
        {
            this.PreviousOne.SetActive(false);
        }
        this.SpawnHurdle();
    }

    public void RestoreScale()
    {
        this.transform.localScale = new Vector3(1, 1, 1);
    }

   public void DestroyObject()
    {
        this.Hurdlepool.DestroyObject(this.gameObject);
    }

    void SpawnHurdle()
    {
        int rand = Random.Range(0, this.HurdlesChild-this.IndexOffset);
        GameObject g = this.transform.GetChild(rand).gameObject;
        g.SetActive(true);
        this.PreviousOne = g;
        g.transform.root.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        g.GetComponent<Visibility>().SeenOnScreen = false;
        this.ActiveHurdle = g;
    }

    public void MakeITTrigger()
    {
        this.ActiveHurdle.transform.root.gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }

    public void MarkVisible()
    {
        if(this.IsNormalHurdle)
        this.ActiveHurdle.GetComponent<Visibility>().SeenOnScreen = true;
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
        
        }
    }
}
