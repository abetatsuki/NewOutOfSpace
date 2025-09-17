using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]RayCastController _raycastController;
    [SerializeField]PlayerInputNotifier _playerInputNotifier;

    private void OnEnable()
    {
        _playerInputNotifier.OnThrow += dooor;
    }

    private void OnDisable()
    {
        _playerInputNotifier.OnThrow -= dooor;
    }

    public void dooor()
    {
        GameObject doorObject = _raycastController.GetDoorUnderMouse();
        if (doorObject != null)
        {
            Door door = doorObject.GetComponent<Door>();
            if (door != null)
            {
                door.ToggleDoor();
            }
        }
    }

}
