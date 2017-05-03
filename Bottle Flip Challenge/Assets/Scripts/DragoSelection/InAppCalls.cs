using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InAppCalls : MonoBehaviour {

    public GameObject dragonSelection;
    public AudioSource buttonClick;
    public CanvasGroup mainCanves;

    void OnEnable()
    {
        mainCanves.interactable = false;
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClickDeal1()
    {

        if (!buttonClick.isPlaying)
        {
            buttonClick.Play();
        }
        dragonSelection.SetActive(true);
        mainCanves.interactable = true;
        gameObject.SetActive(false);
    }
    public void OnClickDeal2()
    {
        if (!buttonClick.isPlaying)
        {
            buttonClick.Play();
        }
        dragonSelection.SetActive(true);
        mainCanves.interactable = true;
        gameObject.SetActive(false);
    }

    public void OnClickDeal3()
    {
        if (!buttonClick.isPlaying)
        {
            buttonClick.Play();
        }
        dragonSelection.SetActive(true);
        mainCanves.interactable = true;
        gameObject.SetActive(false);
    }

    public void OnClickDeal4()
    {
        if (!buttonClick.isPlaying)
        {
            buttonClick.Play();
        }
        dragonSelection.SetActive(true);
        mainCanves.interactable = true;
        gameObject.SetActive(false);
    }

    public void OnClickDeal5()
    {
        if (!buttonClick.isPlaying)
        {
            buttonClick.Play();
        }
        dragonSelection.SetActive(true);
        mainCanves.interactable = true;
        gameObject.SetActive(false);
    }

    public void OnClickBack()
    {
        if (!buttonClick.isPlaying)
        {
            buttonClick.Play();
        }
        dragonSelection.SetActive(true);
        mainCanves.interactable = true;
        gameObject.SetActive(false);
    }
}
