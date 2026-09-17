using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueLine[] dialogueLines;
    [SerializeField] private DialogueManager dialogueManager;

    public void Interact()
    {
        transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0f), 0.25f);

        dialogueManager.StartDialogue(dialogueLines);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInteraction playerInteraction = other.GetComponent<PlayerInteraction>();

        if (playerInteraction != null)
        { 
            playerInteraction.SetInteractable(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerInteraction playerInteraction = other.GetComponent<PlayerInteraction>();

        if (playerInteraction != null)
        {
            playerInteraction.ClearInteractable(this);
        }
    }
}
