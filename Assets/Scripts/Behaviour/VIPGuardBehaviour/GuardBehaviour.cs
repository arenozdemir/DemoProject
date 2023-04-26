using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardBehaviour : NPCBehaviour
{
    [SerializeField] bool isDistorbed;
    float timer;
    private void Start()
    {
        animator.SetFloat("cycleOffset", Random.Range(0, 1f));
    }
    public void SetIsDistorbed(bool v)
    {
        isDistorbed = v;
    }
    protected override void Update() {
        //Will be deleted
        base.Update();
        if (isDistorbed)
        {
            timer += Time.deltaTime;
            if (timer >= 3f)
            {
                isDistorbed = false;
                timer = 0;
            }
        }
    }
}
