using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTiltController : MonoBehaviour
{
    public GameObject cube;
    public Rigidbody cubeRB;

    public GameObject cubeRotateTowardsXPos;
    public GameObject cubeRotateTowardsXNeg;
    public GameObject cubeRotateTowardsZNeg;
    public GameObject cubeRotateTowardsZPos;




    // Start is called before the first frame update
    void Start()
    {
        cube = this.gameObject;
        cubeRB = cube.gameObject.GetComponent<Rigidbody>();
        cubeRotateTowardsXPos = GameObject.Find("RotateTowardsXPos");
        cubeRotateTowardsXNeg = GameObject.Find("RotateTowardsXNeg");
        cubeRotateTowardsZNeg = GameObject.Find("RotateTowardsZNeg");
        cubeRotateTowardsZPos = GameObject.Find("RotateTowardsZPos");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.S) && cube.transform.rotation.x >= -0.20)
        {
            cubeRotateTowardsXNeg.transform.eulerAngles = new Vector3(-20, 0, cube.transform.eulerAngles.z);
            cubeRB.transform.rotation = Quaternion.RotateTowards(transform.rotation, cubeRotateTowardsXNeg.transform.rotation, 1);
        }
        if (Input.GetKey(KeyCode.W) && cube.transform.rotation.x <= 0.20)
        {
            cubeRotateTowardsXPos.transform.eulerAngles = new Vector3(20, 0, cube.transform.eulerAngles.z);
            cubeRB.transform.rotation = Quaternion.RotateTowards(transform.rotation, cubeRotateTowardsXPos.transform.rotation, 1);
        }
        if (Input.GetKey(KeyCode.A) && cube.transform.rotation.z <= 0.20)
        {
            cubeRotateTowardsZPos.transform.eulerAngles = new Vector3(cube.transform.eulerAngles.x, 0, 20);
            cubeRB.transform.rotation = Quaternion.RotateTowards(transform.rotation, cubeRotateTowardsZPos.transform.rotation, 1);
        }
        if (Input.GetKey(KeyCode.D) && cube.transform.rotation.z >= -0.20)
        {
            cubeRotateTowardsZNeg.transform.eulerAngles = new Vector3(cube.transform.eulerAngles.x, 0, -20);
            cubeRB.transform.rotation = Quaternion.RotateTowards(transform.rotation, cubeRotateTowardsZNeg.transform.rotation, 1);
        }
    }
}
