using UnityEngine;
using System.Collections;

public class FirstScript : MonoBehaviour
{
    public float speed = 20;
    public Rigidbody projectile;
    public Rigidbody cube;
    public float cubeW = 1.0f;
    public float cubeH = 1.0f;
    //Vector3 posChange = new Vector3(2, 2, 0);

    // Use this for initialization
    void Start()
    {

        GameObject cube = new GameObject();

        for (int x = 0; x < 9; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                float posX = 430.0f;
                float posY = 0.528f;
                float posZ = 220.0f;

                Vector3 position_ = new Vector3(posX + y * cubeW, posY + x * cubeH, posZ);

                //Rigidbody instanstiateCube = Instantiate(cube, transform.position = positionCube, transform.rotation) as Rigidbody;

                cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = position_;

                Rigidbody gameObjectsRigidBody = cube.AddComponent<Rigidbody>(); // Add the rigidbody.
                gameObjectsRigidBody.mass = 0.5f;//Set the GO's mass to 1 via the Rigidbody.
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("I am alive!");
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody instanstiateProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instanstiateProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));

            Debug.Log("Firing");

        }

    }

}

