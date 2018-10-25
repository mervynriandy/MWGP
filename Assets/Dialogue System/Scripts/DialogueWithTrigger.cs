using UnityEngine;
using System.Collections;

public class DialogueWithTrigger : BaseDialogue {
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.E) && enter && !talking && Time.timeScale != 0.0f){
			NextMessage();
		}
		
		if (Time.timeScale == 0)
		{
			talking = true;
			Invoke("EnableTalking", 0.1f);
		}
	}

	//MUST RETURN FALSE TO LEAVE DIALOG FLOW AS NORMAL
	public override bool CheckSpecialConditions(int messageNumber)
	{
		if (message[messageNumber].hasTrigger){
			ActivateTrigger(message[messageNumber].triggerID);
		}
		return false;
	}

	//Activates trigger of index "index" on trigger list
	void ActivateTrigger(int index){
//		GetComponent<DialogueTriggerContainer>().Triggers[index].gameObject.SetActive(true);
		GetComponent<DialogueTriggerContainer>().Triggers[index].FireTrigger();
	}
}
