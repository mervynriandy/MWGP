using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour {

    private QuestManager theQM;
	public DialogueManager dm;
    public int questNumber;

    public bool startQuest;
	public bool endQuest;
	// Use this for initialization
	void Start () {
        theQM = FindObjectOfType<QuestManager>();
		dm =FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(startQuest && !theQM.quests[questNumber].gameObject.activeSelf && dm.accepted)
		{
			theQM.quests[questNumber].gameObject.SetActive(true);
		}
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.E))
        {
			if (startQuest && !theQM.questCompleted [questNumber] && !theQM.quests[questNumber].gameObject.activeSelf) {
				theQM.quests [questNumber].StartQuest ();
			}

			if(endQuest && theQM.quests[questNumber].gameObject.activeSelf)
			{
				theQM.quests[questNumber].EndQuest();
			}   
        }
    }
        
}


