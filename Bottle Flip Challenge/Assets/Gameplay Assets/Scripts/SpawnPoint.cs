using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour 
{
    public int Size;
    public int Index;
    public int PreviousIndex;
    void Start()
    {
        Randomize();
    }

    void OnEnable()
    {
        this.Randomize();
    }

    public void Randomize()
    {
        Debug.Log("Check");
        this.transform.GetChild(this.PreviousIndex).gameObject.SetActive(false);
        this.Size = this.transform.childCount;
        this.Index = Random.Range(0, this.Size);
        this.transform.GetChild(this.Index).gameObject.SetActive(true);
        this.PreviousIndex = this.Index;
    }
}
