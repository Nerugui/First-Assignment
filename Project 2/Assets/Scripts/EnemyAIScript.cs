using UnityEngine;
using System.Collections; 

public class EnemyAIScript : MonoBehaviour {
	
	public Transform player; 
	public float playerDistance;
<<<<<<< HEAD
    static int enemyHealth = 3;
	public float rotationDamping;
	public float moveSpeed;
    public static bool isPlayerAlive = true;
    public static bool isEnemyAlive = true;

    //use this for initialization 
    void Start() {
=======
	public float rotationDamping;
	public float moveSpeed; 
	public float enemyHealth = 3;

	public Rigidbody projectile;
	public float speed = 20;
	
	//use this for initialization 
	void Start() {
>>>>>>> origin/master
		
	} 
	
	
	//Update is called once per frame
<<<<<<< HEAD
	void Update () {
        death();

        if (isPlayerAlive && isEnemyAlive)
        {
            playerDistance = Vector3.Distance(player.position, transform.position);

            //have the enemy look at the player
            if (playerDistance < 15.0f)
            {
                lookAtPlayer();
            }

            if (playerDistance < 12.0f && playerDistance > 3.5f)
            {
                chasePlayer();
            }
            else if (playerDistance <= 4f)
            {
                attack();
            }

        }
=======
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



>>>>>>> origin/master
	}
	
	void lookAtPlayer() {
		Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
		
		//rotate the enemy 
		transform.rotation = Quaternion.Slerp(transform.rotation,rotation,Time.deltaTime * rotationDamping);
<<<<<<< HEAD
=======
		
>>>>>>> origin/master
	}

	void chasePlayer() {
		 transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
	}

<<<<<<< HEAD
    void attack()
    {
        RaycastHit hit;
        if(Physics.Raycast (transform.position, transform.forward, out hit))
        {
            if(hit.collider.gameObject.tag == "Player")
            {
                hit.collider.gameObject.GetComponent<healthScript01>().health -= 5f;
            }
        }
    }
    
   void death()
    {
        if (enemyHealth < 0)
        {
            isEnemyAlive = false;
            Destroy(gameObject);
        }
    }

    public static void UpdateHealth(int addedValue)
    {
        enemyHealth += addedValue;
    }
=======
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




>>>>>>> origin/master
}
