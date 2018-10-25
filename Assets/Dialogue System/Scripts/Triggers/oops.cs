using UnityEngine;
using System.Collections;


public class oops : DialogueTrigger {

	public override void FireTrigger ()
	{
		base.FireTrigger ();
		GameObject.Find("Plane").SetActive(false);
	}
}
