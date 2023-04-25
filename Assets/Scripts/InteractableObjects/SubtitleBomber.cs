using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleBomber : MonoBehaviour
{
    [SerializeField] private List<string> subtitles;
    [SerializeField] float subtitleDuration;

    int currentChild = 0;
    public void NotifyInteractableObjects()
    {
        if (currentChild < subtitles.Count) 
        {
            Debug.Log("SubtitleBomber: NotifyInteractableObjects");
            SubtitleManager.Instance.ShowSubtitle(subtitles[currentChild], subtitleDuration);
            currentChild++;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NotifyInteractableObjects();
        }
    }
}
