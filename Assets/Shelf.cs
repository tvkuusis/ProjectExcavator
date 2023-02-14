using System.Collections.Generic;
using UnityEngine;

public class Shelf : InteractableReceiver
{
    public List<Transform> slotPositions;
    private int _usedSlots = 0;

    public virtual bool OnReceiveInteractable(Interactable i)
    {
        if (_usedSlots < slotPositions.Count)
        {
            i.transform.SetParent(slotPositions[_usedSlots]);
            i.transform.position = slotPositions[_usedSlots].position;
            _usedSlots++;
            return true;
        }

        return false;
    }
}
