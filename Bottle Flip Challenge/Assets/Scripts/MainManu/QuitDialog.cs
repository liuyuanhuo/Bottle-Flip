using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuitDialog : MonoBehaviour {

    public CanvasGroup maincanvesGroup;
    public AudioSource clickSound;


void OnEnable()
    {
        maincanvesGroup.interactable = false;
    }

    public void OnClickYes()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
        Application.Quit();
    }

    public void OnClickNo()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
        maincanvesGroup.interactable = true;
        gameObject.SetActive(false);
    }

}
