
namespace Managers
{
    public interface InteractableManager
    {
        void PrepareInteractable(Machine parent, Interactable interactable);
        void FinalizeInteractable(Machine parent, Interactable interactable);
    }
}
