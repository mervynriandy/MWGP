using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialoguePanel : MonoBehaviour {
	
	public static GameObject dialogueBox;
	public static Text messageToDisplay;
	public static GameObject button1;
	public static GameObject button2;
	public static GameObject button3;

	//Add aditional button gameobjects here if you need more buttons, ie,  public static GameObject button4;


	public static GameObject buttonNext;
	
	public static Text button1Text;
	public static Text button2Text;
	public static Text button3Text;
	
	//add additional text here if you want more buttons, ie ,  public static Text button4Text;
	
	public static BaseDialogue currentDialogue;

	void Start()
	{
		dialogueBox = transform.GetChild(0).gameObject;
		messageToDisplay = dialogueBox.transform.Find("Dialogue Text").GetComponent<Text>();

		button1 = dialogueBox.transform.Find("Choice1").gameObject;
		button2 = dialogueBox.transform.Find("Choice2").gameObject;
		button3 = dialogueBox.transform.Find("Choice3").gameObject;

		//Get the reference if you add more buttons, ie,   button4 = dialogueBox.transform.FindChild("Choice4").gameObject;

		buttonNext = dialogueBox.transform.Find("Next").gameObject;

		button1Text = button1.transform.GetChild(0).GetComponent<Text>();
		button2Text = button2.transform.GetChild(0).GetComponent<Text>();
		button3Text = button3.transform.GetChild(0).GetComponent<Text>();

		//Get the reference if you add more buttons, ie,   button4Text = button4.transform.GetChild(0).GetComponent<Text>();
	}

	public static void ShowDialog()
	{
		int messageIndex = currentDialogue.s - 1;
		dialogueBox.SetActive(true);
		messageToDisplay.text = currentDialogue.message[messageIndex].messageText;

		DisableAllButtons();  //Disables all buttons
		EnableChoices(currentDialogue.message[messageIndex].choices.Length);  //Enables needed buttons
	}

	public static void EndDialog()
	{
		dialogueBox.SetActive(false);
	}

	public void NextMessage()
	{
		currentDialogue.NextMessage();
	}



	//Choices Buttons
	public void FirstDialogueChoice()
	{
		currentDialogue.GoToNextMessage(currentDialogue.message[currentDialogue.s - 1].choiceDestiny[0]);
	}

	public void SecondDialogueChoice()
	{
		currentDialogue.GoToNextMessage(currentDialogue.message[currentDialogue.s - 1].choiceDestiny[1]);
	}

	public void ThirdDialogueChoice()
	{
		currentDialogue.GoToNextMessage(currentDialogue.message[currentDialogue.s - 1].choiceDestiny[2]);
	}

	//Add more of these if you add more choices (buttons), ie
//	public void FourthDialogueChoice()
//	{
//		currentDialogue.GoToNextMessage(currentDialogue.message[currentDialogue.s - 1].choiceDestiny[3]);
//	}
	//This is the function the new button needs to run


	//This disables all buttons in dialogue, so its easier to enable the proper buttons on next message
	public static void DisableAllButtons()
	{
		button1.SetActive(false);
		button2.SetActive(false);
		button3.SetActive(false);

		//Add more if you have more buttons, ie, button4.SetActive(false);

		buttonNext.SetActive(false);
	}


	public static void EnableChoices(int numberOfChoices)
	{
		if (numberOfChoices == 0)
		{
			buttonNext.SetActive(true);
			EventSystem.current.SetSelectedGameObject(buttonNext);
		}
		else if (numberOfChoices == 1)
		{
			button1.SetActive(true);
			button1Text.text = currentDialogue.message[currentDialogue.s - 1].choices[0];
//			EventSystem.current.SetSelectedGameObject(button1);
		}
		else if (numberOfChoices == 2)
		{
			button1.SetActive(true);
			button1Text.text = currentDialogue.message[currentDialogue.s - 1].choices[0];
			button2.SetActive(true);
			button2Text.text = currentDialogue.message[currentDialogue.s - 1].choices[1];
//			EventSystem.current.SetSelectedGameObject(button1);
		}
		else if (numberOfChoices == 3)
		{
			button1.SetActive(true);
			button1Text.text = currentDialogue.message[currentDialogue.s - 1].choices[0];
			button2.SetActive(true);
			button2Text.text = currentDialogue.message[currentDialogue.s - 1].choices[1];
			button3.SetActive(true);
			button3Text.text = currentDialogue.message[currentDialogue.s - 1].choices[2];
//			EventSystem.current.SetSelectedGameObject(button1);
		}
		//add more if you have more buttons, ie
//		else if (numberOfChoices == 4)
//		{
//			button1.SetActive(true);
//			button1Text.text = currentDialogue.message[currentDialogue.s - 1].choices[0];
//			button2.SetActive(true);
//			button2Text.text = currentDialogue.message[currentDialogue.s - 1].choices[1];
//			button3.SetActive(true);
//			button3Text.text = currentDialogue.message[currentDialogue.s - 1].choices[2];
//			button4.SetActive(true);
//			button4Text.text = currentDialogue.message[currentDialogue.s - 1].choices[3];
//		}

	}
}
