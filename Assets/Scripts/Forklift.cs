using Helpers;
using UnityEngine;

public class Forklift : Machine
{
    [SerializeField] private Transform palletParent;
    public MachineType MachineType { get; set; } = MachineType.Forklift;

    public override void AttachInteractable(Interactable interactable)
    {
        if (interactable.InteractableType != InteractableType.Pallet)
        {
            return;
        }
        
        interactable.transform.SetParent(palletParent);
        interactable.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
    }
}
