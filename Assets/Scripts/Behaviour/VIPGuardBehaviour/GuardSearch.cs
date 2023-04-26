using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSearch : Leaf
{
    PlayerScript player;
    float timer;
    bool isBeginned;
    public override Status Process()
    {
        Begin();
        timer += Time.deltaTime;
        if (timer >= 3f)
        {
            if (player.GetTestObject() != null)
            {
                // yakalandiniz
                Debug.Log("Game over");
            }
            else
            {
                Debug.Log("You May go");
                player.enabled = true;
                //gidebilirsiniz
            }
        }
        return Status.RUNNING;
    }
    void Begin()
    {
        if (!isBeginned)
        {
            player = FindObjectOfType<PlayerScript>();
            isBeginned = true;
        }
    }

}
