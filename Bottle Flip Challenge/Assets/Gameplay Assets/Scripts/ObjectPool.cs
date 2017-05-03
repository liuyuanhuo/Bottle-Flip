using UnityEngine;
using System.Collections;

public class ObjectPool : MonoBehaviour 
{
    private static ObjectPool Instance;
    [SerializeField]
    private Stack<GameObject> pool;
    public GameObject Prefab;
    public int PoolSize = 20;
    public int Threshold;

    void Awake()
    {
        Instance = this;
        this.pool = new Stack<GameObject>(this.PoolSize+this.Threshold);
        this.CreatePool();
    }

    public void AddToPool(GameObject g)
    {
        this.pool.Push(g);
    }

    public GameObject GetObjectFromPool()
    {
        return this.pool.Pop();
    }


    public static ObjectPool GetInstance()
    {   
        return Instance;
    }

    public void CreatePool()
    {
        for (int i = 0; i < this.PoolSize; i++)
        {
            GameObject obj = Instantiate(this.Prefab, Vector3.zero, Quaternion.identity) as GameObject;
            obj.transform.name = obj.name + i.ToString();
            obj.SetActive(false);
            this.AddToPool(obj);
        }
      //  Debug.Log(this.pool.PoolSize());
    }

    public GameObject InstantiateObject(Vector3 Position, Quaternion Rotation)
    {
        GameObject obj =  this.GetObjectFromPool();
      //  Debug.Log(obj);
        obj.transform.position = Position;
        obj.transform.rotation = Rotation;
        obj.SetActive(true);
        return obj;
    }

    public void DestroyObject(GameObject g)
    {
        g.SetActive(false);
        this.AddToPool(g);
    }
}
