using UnityEngine;
using DG.Tweening;

public class DoorLogic : MonoBehaviour
{

    [SerializeField]
    private Transform door;

    [SerializeField]
    private bool[] pressedButtons;

    [SerializeField]
    private bool isOpen;

    public void PressButton(int pID)
    {
        if (pID >= pressedButtons.Length) return;
        pressedButtons[pID] = true;
        CheckRequirements();
    }

    private void CheckRequirements()
    {
        if (isOpen) return;

        foreach (bool button in pressedButtons)
        {
            if (!button) return;
        }

        OpenDoor();
    }

    private void OpenDoor()
    {
        isOpen = true;
        door.DOMoveX(door.position.x - 5, 3);
    }
}
