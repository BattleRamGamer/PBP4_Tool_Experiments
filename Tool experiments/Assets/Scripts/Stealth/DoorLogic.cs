using UnityEngine;
using DG.Tweening;
using TMPro;

public class DoorLogic : MonoBehaviour
{

    [SerializeField]
    private Transform door;

    [SerializeField]
    private TextMeshProUGUI requirementText;

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

        int openAmount = 0;

        foreach (bool button in pressedButtons)
        {
            if (button) openAmount++;
        }

        if (requirementText != null)
        {
            requirementText.text = openAmount.ToString() + "/" + pressedButtons.Length;
        }

        if (openAmount < pressedButtons.Length) return;

        OpenDoor();
    }

    private void OpenDoor()
    {
        isOpen = true;
        door.DOMoveX(door.position.x - 5, 3);
    }
}
