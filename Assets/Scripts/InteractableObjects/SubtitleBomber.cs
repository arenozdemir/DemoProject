using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleBomber : MonoBehaviour
{
    [SerializeField] private string subtitle;
    [SerializeField] float subtitleDuration;
    public void NotifyInteractableObjects()
    {
        Debug.Log("SubtitleBomber: NotifyInteractableObjects");
        SubtitleManager.Instance.ShowSubtitle(subtitle,subtitleDuration);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NotifyInteractableObjects();
        }
    }
}
