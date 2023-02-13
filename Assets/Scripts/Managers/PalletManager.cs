using Helpers;

namespace Managers
{
    public class PalletManager : InteractableManager
    {
        public void PrepareInteractable(Machine machine, Interactable interactable)
        {
            if (interactable.InteractableType != InteractableType.Pallet)
            {
                return;
            }
            
            machine.AttachInteractable(interactable);
        }

        public void FinalizeInteractable(Machine parent, Interactable interactable)
        {
            throw new System.NotImplementedException();
        }
    }
}
