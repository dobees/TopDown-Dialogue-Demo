using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private IInteractable currentInteractable;

    [SerializeField] private GameObject interactionUI;

    void start()
    {
        interactionUI.SetActive(false);
    }

    void Update()
    {
        if (currentInteractable == null)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();
        }
    }

    public void SetInteractable(IInteractable interactable)
    {
        currentInteractable = interactable;

        interactionUI.SetActive(true);
    }

    public void ClearInteractable(IInteractable interactable)
    {
        if (currentInteractable == interactable)
        {
            currentInteractable = null;

            interactionUI.SetActive(false);
        }
    }
}
