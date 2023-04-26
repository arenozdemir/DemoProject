using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcWanderAround : MonoBehaviour
{
    public float range = 100.0f;
    NavMeshAgent agent;
    Vector3 point;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (RandomPoint(transform.position, range, out point))
            {
                agent.SetDestination(point);
            }
            GetComponent<Animator>().SetBool("isWalking",true);
    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere.normalized * range;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(point, transform.position) < 3f)
        {
            if (RandomPoint(transform.position, range, out point))
            {
                agent.SetDestination(point);
            }
        }
    }
}

