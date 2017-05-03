using UnityEngine;
using System.Collections;

public enum GameplaySceneMode
{
    BottleFlip,
    DumpTheBottle
}

public class SceneCalculator : MonoBehaviour {

    public GameplaySceneMode gamePlayMode;

	// Use this for initialization
	void Start () 
    {
        switch (this.gamePlayMode)
        {
            case GameplaySceneMode.BottleFlip:
                PrefsManager.AddToBottleFlipGameCount();
                //Debug.Log(PrefsManager.GetBottleFlipGameCount());
                break;
                
            case GameplaySceneMode.DumpTheBottle:
                PrefsManager.AddToDumpBottleGameCount();
                Debug.Log(PrefsManager.GetDumpBottleGameCount());
                break;
        }
	}
}
