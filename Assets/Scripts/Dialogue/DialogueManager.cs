using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;

    public bool dialogActive;
	public bool udah;
	public bool accepted;
    public string[] dialogLines;
    public int currentLine;
	// Use this for initialization
	void Start () {
		
	}
	public void AcceptButton(bool accept){
		udah = true;
		accepted = accept;
	}
	// Update is called once per frame
	void Update () {

		if(dialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            //dBox.SetActive(false);
            //dialogActive = false;
			if (currentLine < dialogLines.Length - 1) {
				currentLine++;
			
			}
            
        }

        if(currentLine <= dialogLines.Length)
        {
			if (udah) {
				dBox.SetActive (false);
				dialogActive = false;
				currentLine = 0;
				udah = false;

			}
        }

        dText.text = dialogLines[currentLine];
    }

    public void showBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void showDialogue()
    {
        dialogActive = true;
        dBox.SetActive(true);
    }
}
