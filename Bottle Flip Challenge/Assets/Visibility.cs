using UnityEngine;
using System.Collections;

public class Visibility : MonoBehaviour {

    public bool SeenOnScreen;

    public HurdleSpawner parent;
    public Renderer rende;

    void Awake()
    {
        this.SeenOnScreen = false;
        this.parent = this.transform.root.gameObject.GetComponent<HurdleSpawner>();

        this.rende = this.GetComponent<Renderer>();
    }

    void Update()
    {
        //if (!this.SeenOnScreen)
        //{
        //    if (this.rende.isVisible)
        //    {
        //        this.SeenOnScreen = true;
        //    }
        //}
        if (this.SeenOnScreen)
        {
            if (!this.rende.isVisible)
            {
                DestroyObject();
            }
        }
    }

    void DestroyObject()
    {
        Debug.Log("Object Destroying "+this.transform.root.gameObject);
        this.SeenOnScreen = false;
        this.parent.DestroyObject();
     //   CancelInvoke("DestroyObject");
    }

    void OnEnable()
    {
       // this.SeenOnScreen = false;
    }

    //void OnBecameInvisible()
    //{
    //    Debug.Log(this.transform.root.gameObject);
      
    //}

    //void OnBecameVisible()
    //{
    //    this.SeenOnScreen = true;
    //}
}
