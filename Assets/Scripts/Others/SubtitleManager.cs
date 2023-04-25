using UnityEngine;
using TMPro;
using System.Collections;

public class SubtitleManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI subtitleText;
    public static SubtitleManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    IEnumerator SubtitleSetter(string subtitle, float subtitleDuration)
    {
        subtitleText.text = subtitle;
        yield return new WaitForSeconds(subtitleDuration);
        HideText();
    }
        
    public void ShowSubtitle(string subtitle, float subtitleDuration)
    {
        StartCoroutine(SubtitleSetter(subtitle,subtitleDuration));
    }
    void HideText()
    {
        subtitleText.text = "";
    }
}
