using System;
using Helpers;
using Managers;
using UnityEngine;

public class Machine : MonoBehaviour
{
    MachineType MachineType { get; set; }

    public virtual void OnTriggerEnter(Collider other)
    {
        Console.WriteLine("Hit collider " + other.transform.name);
        Interactable i = other.GetComponent<Interactable>();
        PalletManager pm = new PalletManager();
        pm.PrepareInteractable(this, i);
    }

    public virtual void OnTriggerExit(Collider other)
    {
        throw new System.NotImplementedException();
    }
    
    public virtual void AttachInteractable(Interactable interactable)
    {
        
    }
}
