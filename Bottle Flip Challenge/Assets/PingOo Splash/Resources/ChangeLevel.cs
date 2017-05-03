using UnityEngine;
using System.Collections;

public class ChangeLevel : MonoBehaviour
{

    public AudioSource games;
    public AudioSource tag;
    public AudioSource pop;

    void Start()
    {
        Invoke("changeLevel", 5.0f);
    }


    void changeLevel()
    {
        Application.LoadLevel(1);
    }

    void playAudioGames()
    {
        games.Play();
    }

    void stopAudioGames()
    {
        games.Stop();
    }

    void playAudioTag()
    {
        tag.Play();
    }
    void stopAudioTag()
    {
        tag.Stop();
    }

    void playAudiopop()
    {
        pop.Play();
    }
    void stopAudiopop()
    {
        pop.Stop();
    }
}
