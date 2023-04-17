using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public enum Status{
        SUCCESS,
        FAILURE,
        RUNNING
    }
    public Status status;
    protected List<Node> children = new List<Node>();
    protected int currentChild = 0;
    public virtual Status Process()
    {
        return children[currentChild].Process();    
    }
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).TryGetComponent(out Node node))
            {
                children.Add(node);
            }
        }
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
}
