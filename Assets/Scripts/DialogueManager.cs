using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [SerializeField] private Text npc_name;
    [SerializeField] private Text dialogue;

    [SerializeField] private Animator animator;

    private Queue<string> Sentences;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DialogueManager dans la scène");
            return;
        }
        Instance = this;

        Sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue new_dialogue)
    {
        animator.SetBool("IsOpen", true);

        npc_name.text = new_dialogue.GetNpcName();

        Sentences.Clear();

        foreach (string sentence in new_dialogue.GetSentences())
        {
            Sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (Sentences.Count == 0)
        {
            EndDialogue();
            return;
            
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(TypeSentence(Sentences.Dequeue()));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogue.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogue.text+=letter;
            yield return null;
        }
    }


    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
