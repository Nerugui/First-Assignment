using UnityEngine;
using System.Collections;

public class healthScript01 : MonoBehaviour {

    public float health;
   


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(health < 0f)
        {
            EnemyAIScript.isPlayerAlive = false;
            Destroy(gameObject);
        }

	}
}
