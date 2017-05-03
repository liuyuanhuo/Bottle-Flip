using UnityEngine;
using System.Collections;

public class LerpCoins : MonoBehaviour {
    public Vector3 startPos;
    public Vector3 finelPos;

    public float lerpSpeed=0.001f;

    private float timer = 0f;


    void Start()
    {
        Invoke("DestroyIt", 0.3f);
    }

	// Update is called once per frame
	void Update () {
        if (timer<1)
        {
            timer += lerpSpeed;
            this.transform.position = Vector3.Lerp(startPos, finelPos, timer);
        }
        //else
        //{
        //    Destroy(this);
        //}
	}

    void DestroyIt()
    {
        Destroy(this.gameObject);
    }
}
