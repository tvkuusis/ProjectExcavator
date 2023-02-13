
namespace Managers
{
    public interface InteractableManager
    {
        void PrepareInteractable(IMachineController parent, IInteractable interactable);
        void FinalizeInteractable(IMachineController parent, IInteractable interactable);
    }
}
