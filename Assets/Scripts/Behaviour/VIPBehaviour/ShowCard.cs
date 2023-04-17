using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCard : Leaf
{
    [SerializeField] GameObject card;
    [SerializeField] AnimationClip showCardAnimation;
    bool isBeginned = false;
    float timer;
    public override Status Process()
    {
        if (card.transform.parent == null && timer <= 0)
        {
            return Status.FAILURE;
        }
        else if (timer < 0)
        {
            return Status.SUCCESS;
        }
        Begin();
        timer -= Time.deltaTime;
        return Status.RUNNING;
    }
    private void Begin(){
        if (!isBeginned)
        {
            timer = showCardAnimation.length;
            animator.CrossFade("Happy Hand Gesture", 0.1f);
            isBeginned = true;
        }
    }
}
