using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;



public class States : MonoBehaviour
{

    public AudioSource clickSound;

    public Text BF_gamePlayed;
    public Text BF_SuccessfullFlip;
    public Text BF_Distance;

    public Text DTB_gamePlayed;
    public Text DTB_SuccessfullDump;

    public Text TotalCoins;

    void Awake()
    {
        Time.timeScale = 1;
        //AppController.chartBoostMainMenu = true;

        BF_gamePlayed.text = PrefsManager.GetBottleFlipGameCount().ToString();
        BF_SuccessfullFlip.text = PrefsManager.GetTotalSuccessFullFlips().ToString();//bottleflip SuccessfullFlip
        BF_Distance.text = PrefsManager.GetHighestDistance().ToString();//bottleflip Distance

        DTB_gamePlayed.text = PrefsManager.GetDumpBottleGameCount().ToString();//dump the bottle gameplay
        DTB_SuccessfullDump.text = PrefsManager.GetTotalSuccessFullDumps().ToString();//dump the bottle SuccessfullDump
        this.TotalCoins.text = PrefsManager.GetTotalCoins().ToString();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("1-MainMenu");
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
        SceneManager.LoadScene("1-MainMenu");
    }
}
