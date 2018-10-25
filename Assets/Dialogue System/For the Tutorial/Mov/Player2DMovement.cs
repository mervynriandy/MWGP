using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Player2DMovement : MonoBehaviour {

	public float offSet;

	public float walkSpeed = 5f;
	public float runSpeed = 7f;

	private CharacterController controller;
	Transform mainCamera;
	Vector3 mainCameraForward;

	public float stamina = 100;
	
	//stamina regen per frame
	public float staminaRegenRate = 0.1f;
	public float staminaDecreaseRate = 0.02f;

//	bool canDash = true;
	public float dashCost = 30;

	public bool moveDirectionFacing = true;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		if (Camera.main != null){
			mainCamera = Camera.main.transform;
		}
		else{
			Debug.Log("No main camera");
		}
	}
	
	// Update is called once per frame
	void Update () {

		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		
		// calculate move direction to pass to character
		if (mainCamera != null)
		{
			// calculate camera relative direction to move:
			mainCameraForward = Vector3.Scale(mainCamera.forward, new Vector3(1, 0, 1)).normalized;
			Vector3 motion = v*mainCameraForward + h*mainCamera.right;
			motion = motion.normalized * (Input.GetKey(KeyCode.LeftShift) && stamina>0?runSpeed:walkSpeed);

//			if(canDash && Input.GetButtonDown("Dash") && stamina >= dashCost){
//				Dash();
//			}

//			motion = transform.InverseTransformDirection(motion);
			if (moveDirectionFacing){
				if (motion.x != 0 | motion.y != 0){
					LookAt(motion);
				}
			}
			controller.Move(motion * Time.deltaTime);
		}

//		if (Input.GetButton("Run")){
//			stamina -= staminaDecreaseRate/10;
//		}
//		else if (stamina< 100){
//			stamina += staminaRegenRate;
//		}
//
//		if (stamina>100){
//			stamina = 100;
//		}

	}

//	void Dash(){
//		walkSpeed = 30;
//		runSpeed = 30;
//
//		canDash = false;
////		stamina -= dashCost;
//		Invoke("ResetSpeed", 0.1f);
//		Invoke("ResetDash", 2f);
//	}
//
//	void ResetSpeed(){
//		walkSpeed = 5f;
//		runSpeed = 7f;
//	}
//
//	void ResetDash(){
//		canDash = true;
//	}

	//This function makes the character face direction
	void LookAt(Vector3 direction){
		float x = direction.x;
		float z = direction.z;
		float yRotation = Mathf.Rad2Deg * Mathf.Atan2(x,z);

		transform.eulerAngles = new Vector3(0,yRotation - offSet,0);
	}
}
