using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITakeable : MonoBehaviour
{
    public virtual void ObjectControl()
    {
        if (transform.parent != null)
        {
            transform.parent = null;
        }
        PlayerScript player = FindObjectOfType<PlayerScript>();
        player.SetTestObject(gameObject);
    }
}
