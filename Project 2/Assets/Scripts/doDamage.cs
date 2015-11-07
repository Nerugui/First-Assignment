using UnityEngine;
using System.Collections;

public class doDamage : MonoBehaviour
{
    void OnCollisionEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            EnemyAIScript.UpdateHealth(-1);
           //GetComponent<EnemyAIScript>().enemyHealth -= 1f;
        }
    }
}

    
    



