using UnityEngine;
using System.Collections;

public class CoinChild : MonoBehaviour 
{
    public GameObject[] Children;
    public int ChildCount;

    void Awake()
    {
        this.ChildCount = this.transform.childCount;
        this.Children = new GameObject[this.ChildCount];
        for (int i = 0; i < this.ChildCount; i++)
        {
            this.Children[i] = this.transform.GetChild(i).gameObject;
        }
    }

    public void AwakeAllChildren()
    {
        for (int i = 0; i < this.ChildCount; i++)
        {
            this.Children[i].SetActive(true);
        }
    }

    public void AwakeSpecificChildren(int startIndex, int childCount)
    {
        for (int i = startIndex; i <= childCount; i++)
        {
            this.Children[i].SetActive(true);
        }
    }
}
