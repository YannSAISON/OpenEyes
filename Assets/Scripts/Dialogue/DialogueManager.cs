using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences = new Queue<string>();
    private Queue<Dialogue> dialogues = new Queue<Dialogue>();
    public Text nameText;
    public Text dialogueText;
    public Image dialogueImage;
    public Animator animator;

    void Start() {
        animator.SetBool("IsOpen", false);
    }

    public void StartDialogue(Dialogue[] dialogue) {
        animator.SetBool("IsOpen", true);

        sentences.Clear();

        foreach (Dialogue dial in dialogue)
        {
            dialogues.Enqueue(dial);
        }
        NextDialogue();
    }

    private void NextDialogue()
    {
        if (dialogues.Count == 0)
        {
            EndDialogue();
            return;
        }

        Dialogue dialogue = dialogues.Dequeue();

        nameText.text = dialogue.name;
        dialogueImage.sprite = dialogue.sprite;

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            NextDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopCoroutine(TypeSentence(sentence));
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue() {
        animator.SetBool("IsOpen", false);
    }
}
