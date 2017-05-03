using UnityEngine;
using System.Collections;

public class AppController : MonoBehaviour
{
    public static int dragoIndex = 0;

    public static float AdTimer = 0.0f;
    public static int gamePlayCount = 0;
    public static bool isOpositDirection = true;
    
    public static bool isMusic = true;
    public static bool isSound = true;
   
    public static bool chartBoostShow = false;
    public static bool chartBoostMainMenu = false;
    public static bool chartBoost = false;
	public static bool isScroller  = false;
	
	public static bool _isDialogue  = false;
	public static bool isCamPic=false;
	public static bool isDialogue  = false;
	public static bool showPurchaseDialogue  = false;
	
	public static int isPurchased  = 0;
	
	public static int gamePlayed  = 1;
	public static int toPlay  = 1;
	
	public static bool isEating = true;
	
    
    public static int alreadyRated = 0;

    public static float getMWidth(float pWidth )  {
		float w_  = ((pWidth * 100f) / 720f);
		return ((w_ /100.00f) *Screen.width);
	}
	
	public static float getMHeight(float pHeight )  {
		float h_  = ((pHeight * 100f) /1280f);
		return ((h_ /100.0f) * Screen.height);
	}
	
	public static float getRWidth(float pWidth ) {
		float w_  = ((pWidth * 100f) / Screen.width);
		return ((w_ /100.0f) * 720f);
		
	}
	
	public static float getRHeight(float pHeight ) {
		float h_  = ((pHeight * 100f) / Screen.height);
		return ((h_ /100.0f) * 1280f);
	}
}
