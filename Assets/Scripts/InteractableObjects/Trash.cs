using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Trash : MonoBehaviour, IDistorber, InteractableObjectsInterface
{
    [SerializeField] float distorbRange;
    [SerializeField] GameObject player;
    [SerializeField] Transform point;
    bool isShake;
    float timer = 0;
    bool usedOnce = true;
    float elapsed = 0;
    public void Distorb()
    {
        Collider[] guards = Physics.OverlapSphere(transform.position, distorbRange);
        foreach (Collider guard in guards)
        {
            if (guard.TryGetComponent(out GuardBehaviour guardBehaviour))
            {
                guardBehaviour.SetIsDistorbed(true, this.transform);
            }
        }
    }
    public void NotifyInteractableObjects()
    {
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
                float y = Random.Range(-.5f, .5f) * .3f;
                Camera.main.transform.localPosition = new Vector3(Camera.main.transform.localPosition.x, Camera.main.transform.localPosition.y + y, originalPos.z);
            }
            else
            {
                Camera.main.transform.localPosition = originalPos;
                isShake = false;
                usedOnce = false;
            }
        }
        if (!usedOnce)
        {
            Distorb();
            usedOnce = true;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distorbRange);
    }
    private IEnumerator SetPlayerPosition()
    {
        while (timer <= 3f)
        {
            timer += Time.deltaTime;
            player.GetComponent<NavMeshAgent>().SetDestination(point.position);
            player.GetComponent<Animator>().SetBool("isWalking", true);
            if (Vector3.Distance(player.transform.position, point.position) < .5)
            {
                player.GetComponent<Animator>().SetBool("isWalking", false);
                player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.LookRotation(Vector3.back), Time.deltaTime * 5);
            }
            yield return null;
        }
        yield return new WaitForSeconds(1);
        isShake = true;
    }
}
