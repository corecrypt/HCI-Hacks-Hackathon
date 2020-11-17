using UnityEngine;
using UnityEngine.Events;

public class InteractableButton : Interactable
{
    public UnityEvent onButtonPressed;

    public override void Interact(GameObject player)
    {
        base.Interact(player);
        onButtonPressed?.Invoke();
    }
}
