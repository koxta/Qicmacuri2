using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

    public Canvas canvas;

	private Queue<string> sentences;

    private List<Dialogue> dialogueList;

	// Use this for initialization
	void Start () {
        canvas.enabled = false;
        dialogueList = new List<Dialogue>();


        sentences = new Queue<string>();
	}

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.X) && canvas.enabled)
        {
            //do stuff
            DisplayNextSentence();
        }
    }

	public void StartDialogue (Dialogue dialogue)
	{

        if (dialogueList.Contains(dialogue))
            return;

        dialogueList.Add(dialogue);


        nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
        canvas.enabled = true;

        if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
        canvas.enabled = false;
	}

}
