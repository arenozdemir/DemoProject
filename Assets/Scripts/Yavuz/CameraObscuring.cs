using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObscuring : MonoBehaviour
{
    Transform  player;
    Dictionary<Collider, int> obscuringObjects = new Dictionary<Collider, int>();
    CapsuleCollider capsuleCollider;
    [SerializeField] float mesafe;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);
        capsuleCollider.center = new Vector3(capsuleCollider.center.x,capsuleCollider.center.y) + Vector3.forward * (dist -mesafe) * 0.5f;
        capsuleCollider.height = dist - mesafe;
        transform.LookAt(player);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            obscuringObjects.Add(other, other.gameObject.layer);
            other.gameObject.layer = LayerMask.NameToLayer("Obscured");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            other.gameObject.layer = obscuringObjects[other];
            obscuringObjects.Remove(other);
        }
    }   
}
