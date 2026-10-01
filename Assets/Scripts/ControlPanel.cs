using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    [SerializeField] private DoorController door;

    public void Activate()
    {

        if (door == null)
        {
            return;
        }

        door.OpenDoor();
    }
}