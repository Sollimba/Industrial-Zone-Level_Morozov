using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    [Header("Door")]
    [SerializeField] private Transform door;
    [SerializeField] private Transform pivot;
    [SerializeField] private float openAngle = 25f;
    [SerializeField] private float openSpeed = 5f;

    [Header("Button Light")]
    [SerializeField] private Light buttonLight;
    [SerializeField] private Color openedColor = Color.green;

    private bool isOpen;

    public void OpenDoor()
    {
        if (isOpen)
            return;

        isOpen = true;

        // Меняем цвет света кнопки
        if (buttonLight != null)
        {
            buttonLight.color = openedColor;
        }

        StartCoroutine(OpenDoorCoroutine());
    }

    private IEnumerator OpenDoorCoroutine()
    {
        float angle = 0f;

        while (angle < openAngle)
        {
            float rotation = openSpeed * Time.deltaTime;
            rotation = Mathf.Min(rotation, openAngle - angle);

            door.RotateAround(pivot.position, Vector3.up, rotation);

            angle += rotation;

            yield return null;
        }
    }
}