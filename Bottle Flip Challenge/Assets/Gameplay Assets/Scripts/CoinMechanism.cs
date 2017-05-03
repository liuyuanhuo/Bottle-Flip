using UnityEngine;
using System.Collections;

public enum DestroyMode
{
    Destroy,DeActive
}

public class CoinMechanism : MonoBehaviour {

    private GameManager manager;
    public GameObject Target;
    public float LerpSpeed = 4f;
    public DestroyMode destroyMode = DestroyMode.DeActive;

    // Use this for initialization
    void Start()
    {
        this.manager = GameManager.GetInstance();
    }

    void Update()
    {
        if (this.Target)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, this.Target.transform.position,this.LerpSpeed*Time.deltaTime);
            Invoke("Destroy", 0.4f);
        }
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("CoinCollector"))
        {
            this.Target = GameObject.Find("LerpTarget");
            //for(int i = 0; i < GameManager.CoinPerk; i++)
            //{
            //    GameObject g = (GameObject)Instantiate(this.gameObject, this.transform.position, this.transform.rotation);
            //    CoinMechanism cm = g.GetComponent<CoinMechanism>();
            //    cm.Target = this.Target;
            //    cm.destroyMode = DestroyMode.Destroy;
            //}
            //GameObject G =(GameObject) Instantiate(this.gameObject, this.transform.position, this.transform.rotation);
            //G.GetComponent<CoinMechanism>().Target = this.Target;
            this.manager.AddCoins();
            this.gameObject.SetActive(false);
        }
    }

    void Destroy()
    {
        this.Target = null;
        switch (this.destroyMode)
        {
            case DestroyMode.DeActive:
                this.gameObject.SetActive(false);
                break;

            case DestroyMode.Destroy:
                Destroy(this.gameObject);
                break;
        }
        CancelInvoke();
    }
}
