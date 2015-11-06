using UnityEngine;
using System.Collections; 

public class EnemyAIScript : MonoBehaviour {
	
	public Transform player; 
	public float playerDistance;
	public float rotationDamping;
	public float moveSpeed; 
	public float enemyHealth = 3;

	public Rigidbody projectile;
	public float speed = 20;
	
	//use this for initialization 
	void Start() {
		
	} 
	
	
	//Update is called once per frame
	void Update () { 
		playerDistance = Vector3.Distance (player.position, transform.position);
		
		//have the enemy look at the player
		if (playerDistance <15.0f) { 
			lookAtPlayer(); 
		}

		if (playerDistance < 12.0f && playerDistance > 4.5f) {
			chasePlayer(); 
		}

		if (playerDistance <= 6.0f && playerDistance > 1.0f) {
			shootAtPlayer();
		}



	}
	
	void lookAtPlayer() {
		Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
		
		//rotate the enemy 
		transform.rotation = Quaternion.Slerp(transform.rotation,rotation,Time.deltaTime * rotationDamping);
		
	}

	void chasePlayer() {
		 transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
	}

	void shootAtPlayer() {
		Rigidbody instanstiateProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
		instanstiateProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
	}

	void enemyDeath() { 
		//destroy object when health = 0
		if (enemyHealth == 0){
		//	yield WaitForSeconds(anim.length);
			Destroy(gameObject);
			
		}
	}

	void OnCollisionEnter(Collision collision){

			foreach (ContactPoint contact in collision.contacts) {
				enemyHealth = enemyHealth -1;
			}
	}




}
