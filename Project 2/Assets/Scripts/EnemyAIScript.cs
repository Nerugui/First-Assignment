using UnityEngine;
using System.Collections; 

public class EnemyAIScript : MonoBehaviour {
	
	public Transform player; 
	public float playerDistance;
    static int enemyHealth = 3;
	public float rotationDamping;
	public float moveSpeed;
    public static bool isPlayerAlive = true;
    public static bool isEnemyAlive = true;

    //use this for initialization 
    void Start() {
		
	} 
	
	
	//Update is called once per frame
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
	}
	
	void lookAtPlayer() {
		Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
		
		//rotate the enemy 
		transform.rotation = Quaternion.Slerp(transform.rotation,rotation,Time.deltaTime * rotationDamping);
	}

	void chasePlayer() {
		 transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
	}

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
}
