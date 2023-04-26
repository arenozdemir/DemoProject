using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Otomat : MonoBehaviour,IDistorber,InteractableObjectsInterface
{
    [SerializeField] float distorbRange;
    [SerializeField] GameObject player;
    [SerializeField] GameObject box;
    [SerializeField] Transform point;
    
    bool usedOnce;
    bool isShake;
    float timer = 0;
    float elapsed = 0.0f;
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
        StartCoroutine(SetPlayerPosition());
    }
    private void Update()
    {
        if (isShake)
        {
            elapsed += Time.deltaTime;
            Vector3 originalPos = Camera.main.transform.localPosition;
            if (elapsed < .5f)
            {
                float y = Random.Range(-.5f, .5f) * .5f;
                Camera.main.transform.localPosition = new Vector3(Camera.main.transform.localPosition.x, Camera.main.transform.localPosition.y + y, originalPos.z);
                box.GetComponent<Rigidbody>().isKinematic = false;
            }
            else {
                Camera.main.transform.localPosition = originalPos;
                isShake = false;
            }
        }
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,distorbRange);
    }
    private IEnumerator SetPlayerPosition()
    {
        while (timer <= 4f)
        {
            timer += Time.deltaTime;
            player.GetComponent<NavMeshAgent>().SetDestination(point.position);
            if (Vector3.Distance(player.transform.position, point.position) < 1)
            {
                player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.LookRotation(Vector3.back), Time.deltaTime * 5);
            }
            yield return null;
        }
        yield return new WaitForSeconds(1);
        isShake = true;
    }
}
