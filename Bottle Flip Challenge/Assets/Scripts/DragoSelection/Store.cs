using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;



public class Store : MonoBehaviour {
    public CanvasGroup mainCanvesGroup;
    public Text totelCoins;
    public AudioSource clickSound;

    public static string backScene = "1-MainMenu";

    void Awake()
    {

        Time.timeScale = 1;
        //AppController.chartBoostMainMenu = true;

    }


    void Update()
    {
        totelCoins.text = "" + PrefsManager.GetTotalCoins();

        if (Input.GetKey(KeyCode.Escape) && mainCanvesGroup.interactable)
        {
            SceneManager.LoadScene(backScene);
        }
    }


    public void OnClickBottleFlip()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
        SceneManager.LoadScene("4-BottleFlip");
    }

    public void OnClickDumpTheBall()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
        SceneManager.LoadScene("5-DumpTheBall");
    }

    public void OnClickBack()
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }
        SceneManager.LoadScene(backScene);
    }
}
