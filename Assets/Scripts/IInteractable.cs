using UnityEngine;

public interface IInteractable
{
    void OnTriggerEnter(Collider other);
    void OnTriggerExit(Collider other);
    void OnDeploy();
}
