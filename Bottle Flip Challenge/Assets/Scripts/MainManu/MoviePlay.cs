using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MoviePlay : MonoBehaviour {
    public string path;

    public GameObject text;

    IEnumerator Start()
    {
        yield return StartCoroutine(PlayMovie());
    }
    IEnumerator PlayMovie()
    {
        if (PrefsManager.getFirstTimePlayStatus()==0)
        {
            text.SetActive(false);
            Debug.Log("firstTimePlay");
            Handheld.PlayFullScreenMovie(path, Color.black, FullScreenMovieControlMode.Hidden);
            PrefsManager.setFirstTimePLay();
        }
        else
        {
            text.SetActive(false);
            Debug.Log("SkipMovie");
            Handheld.PlayFullScreenMovie(path, Color.black, FullScreenMovieControlMode.CancelOnInput);
        }
        yield return new WaitForEndOfFrame();
        SceneManager.LoadScene("MainMenu");
        //Application.LoadLevel(2);
    }
	
}
