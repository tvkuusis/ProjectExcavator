using System;
using Helpers;
using Managers;
using UnityEngine;

public class Machine : MonoBehaviour
{
    MachineType MachineType { get; set; }

    public virtual void OnTriggerEnter(Collider other)
    {

    }

    public virtual void AttachInteractable(Interactable interactable)
    {
        
    }
    
    public virtual void DetachInteractable()
    {
        
    }
}
