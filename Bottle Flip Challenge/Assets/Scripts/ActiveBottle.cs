using UnityEngine;
using System.Collections;

public class ActiveBottle : MonoBehaviour
{
    public GameObject Bottle;

    void Awake()
    {
        this.transform.GetChild(PlayerPrefs.GetInt("BottleSelected")).gameObject.SetActive(true);
        this.Bottle = this.transform.GetChild(PlayerPrefs.GetInt("BottleSelected")).gameObject;
    }
}
