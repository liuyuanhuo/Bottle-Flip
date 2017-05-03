using UnityEngine;
using System.Collections;

public class PlayAnimation : MonoBehaviour {
    private Animator dragoAnimator;
    public int dragoIndex;
    public Animator camAnimator;

    void Awake()
    {
        dragoAnimator = this.GetComponent<Animator>();
    }

    void OnEnable()
    {
        if (dragoIndex == AppController.dragoIndex)
        {
            defualtAnimation();
        }
    }

    void defualtAnimation()
    {
        camAnimator.SetTrigger("ZoomOut");
        Invoke("ActiveDragon", 0.4f);
    }

    void  ActiveDragon()
    {
        dragoAnimator.SetTrigger("Up");
    }

    public void playAnim(string trigger)
    {
        if(trigger== "Up")
        {
            camAnimator.SetTrigger("ZoomOut");
        }
        dragoAnimator.SetTrigger(trigger);
    }
}
