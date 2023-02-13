using System;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class TouchManager : MonoBehaviour
{
    public LayerMask physicsLayers;
    public GameObject testObject;
    [SerializeField] private IMachineController _playerController;
    [SerializeField] private NavMeshAgent _playerAgent;

    
    void OnEnable()
    {
        TouchSimulation.Enable();
        EnhancedTouchSupport.Enable();
    }
    
    void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    
    void Start()
    {
        print("Hello");
    }

    void Update()
    {
        bool canPlaceHere;
        Vector3 targetPosition;

        if (Touch.activeFingers.Count == 0) return;
        
        Touch activeTouch = Touch.activeFingers[0].currentTouch;
        /*for (var i = 0; i < activeTouches.Count; ++i)
            Debug.Log("Active touch: " + activeTouches[i]);*/
        
        //Calculates the direction of the Raycast based on the screenPosition of the touch
        Ray directionOfTouch = Camera.main.ScreenPointToRay(activeTouch.screenPosition);

        //Does a raycast for all objects that are layers 8 and 9 and then orders the results
        RaycastHit[] hitpoints = Physics.RaycastAll(directionOfTouch.origin, directionOfTouch.direction, 
            Mathf.Infinity, physicsLayers).OrderBy(x => x.transform.gameObject.layer).ToArray();

        if (hitpoints.Length == 0) { return; }

        //Can only ever hit up to two colliders. If two have been hit, the last one will be the tile
        int index = hitpoints.Length == 2 ? 1 : 0;

        //The model can only exist if it is being placed on the world tile
        canPlaceHere = hitpoints.Length == 2;

        //For visually debugging in the scene
        Debug.DrawRay(hitpoints[index].point, Vector3.up * 2f, Color.cyan, 0.5f);
        Debug.DrawLine(directionOfTouch.origin, hitpoints[index].point, Color.yellow, 0.5f);

        //Set the calculated target position
        targetPosition = hitpoints[index].point;
        // testObject.transform.position = targetPosition;
        _playerAgent.SetDestination(targetPosition);
    }
}
