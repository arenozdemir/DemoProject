using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CivilQueueMovement : MonoBehaviour
{
    bool isFirst;
    [SerializeField] CivilQueueMovement inBack;
    [SerializeField] Transform lastPos;
    float timer;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFirst)
        {
            timer += Time.deltaTime;
            if(timer >=3f)
            {
                inBack.isFirst = true;
                isFirst = false;
                timer = 0;
                GetComponent<NavMeshAgent>().SetDestination(lastPos.position);
            }
        }
    }
}
