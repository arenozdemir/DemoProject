using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardBehaviour : NPCBehaviour
{
    [SerializeField] bool isDistorbed;
    float timer;
    public PlayerScript player;
    [SerializeField] Node distorbedSequence;
    Transform distorber;
    private void Start()
    {
        player = FindObjectOfType<PlayerScript>();
        animator.SetFloat("cycleOffset", Random.Range(0, 1f));
    }
    public void SetIsDistorbed(bool v,Transform distorber)
    {
        this.distorber = distorber;
        isDistorbed = v;
    }
    protected override void Update() {
        //Will be deleted
        base.Update();
        if (isDistorbed)
        {
           tree = distorbedSequence;
        }
    }
    public Transform GetDistorber()
    {
        return distorber;
    }
}
