using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otomat : MonoBehaviour,IDistorber,InteractableObjectsInterface
{
    [SerializeField] float distorbRange;
    bool usedOnce;
    public void Distorb()
    {
        // Distorb all Guards with in range
        Collider[] guards = Physics.OverlapSphere(transform.position, distorbRange);
        foreach (Collider guard in guards)
        {
            if (guard.TryGetComponent(out GuardBehaviour guardBehaviour))
            {
                guardBehaviour.SetIsDistorbed(true);
            }
        }
    }

    public void NotifyInteractableObjects()
    {
        if(!usedOnce)
        {
            Distorb();
            usedOnce = true;
        }
        
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,distorbRange);
    }
}
