using UnityEngine;
using System.Collections;

public class EnvronmentManager : MonoBehaviour {

    public GameObject EnvironmentPrefab;
    public BoxCollider collider;
    public Vector3 distanceOffset;
    public GameObject EnvironmentParent;
    public ObjectPool EnvironmentPool;
    public CoinChild CoinTransform;


    void OnEnable()
    {

    }

    void EnableCoins()
    {
        this.CoinTransform.AwakeAllChildren();
    }

    public void EnableCollider()
    {
        this.collider.enabled = true;
    }

    void Awake()
    {
        this.collider = this.GetComponent<BoxCollider>();
        this.EnvironmentParent = this.transform.root.gameObject;
        this.EnvironmentPool = GameObject.Find("EnvironmentPool").GetComponent<ObjectPool>();
        this.CoinTransform = this.GetComponentInChildren<CoinChild>();
    }

    void DestroyEnvironment()
    {
        GameObject G = this.EnvironmentParent.transform.GetChild(0).gameObject;
        G.transform.parent = null;
        this.EnvironmentPool.DestroyObject(G);
    }

    void SpawnEnvironment()
    {
        Vector3 spawnPosition = this.transform.position + this.distanceOffset;
        GameObject g = this.EnvironmentPool.InstantiateObject(spawnPosition, this.transform.rotation);
        EnvronmentManager manager = g.GetComponent<EnvronmentManager>();
        manager.EnableCollider();
        manager.EnableCoins();
        g.transform.parent = this.EnvironmentParent.transform;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            this.DestroyEnvironment();
            this.SpawnEnvironment();
        }
    }
}
