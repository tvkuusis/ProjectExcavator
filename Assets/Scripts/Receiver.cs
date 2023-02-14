using Helpers;
using UnityEngine;

public class InteractableReceiver : MonoBehaviour
{
    public InteractableType AllowedInteractable { get; set; }

    public virtual void OnReceiveInteractable()
    {
        
    }
}
