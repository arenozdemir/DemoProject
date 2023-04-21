using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSneaking : MonoBehaviour, IObserver
{
    public void OnNotify(PlayerActionsEnum action)
    {
        if (action == PlayerActionsEnum.Sneaking)
        {
            Debug.Log("Sneaking");
        }
    }
    private void OnEnable()
    {
        ObserverManager.Instance.AddObserver(this);
    }
    private void OnDisable()
    {
        ObserverManager.Instance.RemoveObserver(this);
    }
}
