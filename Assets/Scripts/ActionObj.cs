using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionObj : MonoBehaviour
{
    
    [SerializeField] private bool isInfinity;
    private bool isUsed;
    [SerializeField] private GameObject dialogIcon;
    
    public UnityEvent Action;
    public bool isUsable;
    [SerializeField] private bool isDestroy;

    public void InvokeAction()
    {
        if (!isUsed)
        {
            Action.Invoke();
            isUsed = !isInfinity;
            if(isDestroy){
                Destroy(gameObject);
            }
        }
    }
}
