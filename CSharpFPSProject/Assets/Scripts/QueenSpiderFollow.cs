//Jimmy Vegas Unity 5 Tutorial
//These scripts will allow your spider to have AI
using UnityEngine;
using System.Collections;
//spider follow

public class QueenSpiderFollow : MonoBehaviour {

	public GameObject ThePlayer;
	public float TargetDistance;
	public float AllowedRange = 30;
	public GameObject TheEnemy;
	public float EnemySpeed;
	public int AttackTrigger;
	public RaycastHit Shot;

	public int IsAttacking;
	public GameObject ScreenFlash;
	public AudioSource Hurt01;
	public AudioSource Hurt02;
	public AudioSource Hurt03;
	public int PainSound;
	public int AttackChoice;

	void Update() 
	{
		transform.LookAt (ThePlayer.transform);
		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out Shot)) 
		{
			TargetDistance = Shot.distance;
			if (TargetDistance < AllowedRange) 
			{
				EnemySpeed = 0.03f;
				if (AttackTrigger == 0) 
				{
					TheEnemy.GetComponent<Animation> ().Play ("Walk");
					// Vector3 newYPos = new Vector3(ThePlayer.transform.position, 0, 0);
					transform.position = Vector3.MoveTowards (transform.position,new Vector3(ThePlayer.transform.position.x,transform.position.y,ThePlayer.transform.position.z) , EnemySpeed);
				}
			} 
			else 
			{
				EnemySpeed = 0;
				TheEnemy.GetComponent<Animation> ().Play ("Idle");
			}
		}

		if (AttackTrigger == 1) 
		{
			EnemySpeed = 0;
			if (IsAttacking == 0) 
			{
				StartCoroutine (EnemyDamage());
			}
			TheEnemy.GetComponent<Animation> ().Play ("Attack_Right");
			// TheEnemy.GetComponent<Animation> ().Play ("Attack_Left");
			// StartCoroutine (EnemyAttack());
		}
	}

	void OnTriggerEnter() 
	{
		AttackTrigger = 1;
	}

	void OnTriggerExit() 
	{
		AttackTrigger = 0;
	}
	// IEnumerator EnemyAttack()
	// {
	// 	AttackChoice = Random.Range (1,3);
	// 	if(AttackChoice == 1)
	// 	{
	// 		yield return new WaitForSeconds (.4f);
	// 		TheEnemy.GetComponent<Animation> ().Play ("Attack_Right");
	// 	}
	// 	if(AttackChoice == 2)
	// 	{
	// 		yield return new WaitForSeconds (.4f);
	// 		TheEnemy.GetComponent<Animation> ().Play ("Attack_Left");
	// 	}

	// }
	IEnumerator EnemyDamage() 
	{
		IsAttacking = 1;
		PainSound = Random.Range (1,4);
		yield return new WaitForSeconds (0.2f);
		ScreenFlash.SetActive (true);
		GlobalHealth.PlayerHealth -= 5;
		if (PainSound == 1) 
		{
			Hurt01.Play ();
		}
		if (PainSound == 2) 
		{
			Hurt02.Play ();
		}
		if (PainSound == 3) 
		{
			Hurt03.Play ();
		}
		yield return new WaitForSeconds (0.04f);
		ScreenFlash.SetActive (false);
		yield return new WaitForSeconds (0.75f);
		IsAttacking = 0;

	}
	void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
	}


}