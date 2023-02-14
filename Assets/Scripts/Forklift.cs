using Helpers;
using Managers;
using UnityEngine;

public class Forklift : Machine
{
    [SerializeField] private Transform palletParent;
    public MachineType MachineType { get; set; } = MachineType.Forklift;

    [SerializeField] private Interactable _carriedInteractable = null;
    private readonly PalletManager _pm = new PalletManager();

    public override void OnTriggerEnter(Collider other)
    {
        if (_carriedInteractable)
        {
            var s = other.GetComponent<Shelf>();
            if (!s) return;
            if (s.OnReceiveInteractable(_carriedInteractable))
            {
                _carriedInteractable = null;
            }
        }
        else
        {
            var i = other.GetComponent<Interactable>();
            if (!i) return;
            _pm.PrepareInteractable(this, i);
        }
    }
    
    public override void AttachInteractable(Interactable interactable)
    {
        if (interactable.InteractableType != InteractableType.Pallet)
        {
            return;
        }

        _carriedInteractable = interactable;
        interactable.transform.SetParent(palletParent);
        interactable.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
    }
}
