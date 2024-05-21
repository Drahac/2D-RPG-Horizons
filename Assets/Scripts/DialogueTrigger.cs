using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    [SerializeField] private Dialogue dialogue;

    private bool isInRange;

    [SerializeField] private GameObject interactUI;


    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            interactUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interactUI.SetActive(false);
            DialogueManager.Instance.EndDialogue();
        }
    }

    void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }
}
