using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    Leaf GoToLeaf;
    void Start()
    {
        GoToLeaf = GetComponent<Leaf>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GoToLeaf.Process());
    }
}
