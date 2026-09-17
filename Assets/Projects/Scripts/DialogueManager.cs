using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class DialogueManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text speakerText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Button nextButton;

    [SerializeField] private GameObject interactiveUI;
    [SerializeField] private PlayerController playerController;

    [Header("Animation")]
    [SerializeField] RectTransform dialoguePanelTransform;
    [SerializeField] CanvasGroup dialogueCanvasGroup;

    private DialogueLine[] currentLines;

    private int currentIndex;

    private bool isDialogueActive;

    private void Start()
    {
        nextButton.onClick.AddListener(ShowNextLine);

        dialoguePanel.SetActive(false);
    }

    public void StartDialogue(DialogueLine[] lines)
    {
        if (lines == null || lines.Length == 0)
        {
            return;
        }

        currentLines = lines;
        currentIndex = 0;
        isDialogueActive = true;
        dialoguePanel.SetActive(true);

        playerController.SetCanMove(false);
        interactiveUI.SetActive(false);

        //대화창 등장 애니메이션 준비
        dialoguePanelTransform.localScale = Vector3.zero;
        dialogueCanvasGroup.alpha = 0f;

        ShowCurrentLine();

        //대화창 등장 애니메이션, 확대와 Fade
        Sequence sequence = DOTween.Sequence();

        sequence.Join(
            dialoguePanelTransform
            .DOScale(Vector3.one, 0.25f)
            .SetEase(Ease.OutBack));

        sequence.Join(
            dialogueCanvasGroup.DOFade(1f, 0.2f));
    }

    private void ShowCurrentLine()
    {
        DialogueLine line = currentLines[currentIndex];

        speakerText.text = line.speaker;
        dialogueText.text = line.text;
    }

    public void ShowNextLine()
    {
        if (!isDialogueActive)
        {
            return;
        }

        currentIndex++;

        if (currentIndex >= currentLines.Length)
        {
            EndDialogue();
            return;
        }

        ShowCurrentLine();
    }

    private void EndDialogue()
    {
        //대화창 종료 애니메이션
        Sequence sequence = DOTween.Sequence();

        sequence.Join(
            dialoguePanelTransform.DOScale(Vector3.zero, 0.15f));

        sequence.Join(dialogueCanvasGroup.DOFade(0f, 0.15f));

        sequence.OnComplete(() =>
        {
            currentLines = null;
            dialoguePanel.SetActive(false);

            playerController.SetCanMove(true);
            isDialogueActive = false;
        });
    }
}
