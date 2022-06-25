using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CubeTiltController : MonoBehaviour
{
    private GameObject cube;
    private Rigidbody cubeRB;

    private GameObject cubeRotateTowardsXPos;
    private GameObject cubeRotateTowardsXNeg;
    private GameObject cubeRotateTowardsZNeg;
    private GameObject cubeRotateTowardsZPos;

    private UpButtonManager upButtonManager;
    private DownButtonManager downButtonManager;
    private LeftButtonManager leftButtonManager;
    private RightButtonManager rightButtonManager;

    // Start is called before the first frame update
    void Start()
    {
        cube = this.gameObject;
        cubeRB = cube.gameObject.GetComponent<Rigidbody>();
        cubeRotateTowardsXPos = GameObject.Find("RotateTowardsXPos");
        cubeRotateTowardsXNeg = GameObject.Find("RotateTowardsXNeg");
        cubeRotateTowardsZNeg = GameObject.Find("RotateTowardsZNeg");
        cubeRotateTowardsZPos = GameObject.Find("RotateTowardsZPos");

        upButtonManager = GameObject.Find("UpButton").GetComponent<UpButtonManager>();
        rightButtonManager = GameObject.Find("RightButton").GetComponent<RightButtonManager>();
        leftButtonManager = GameObject.Find("LeftButton").GetComponent<LeftButtonManager>();
        downButtonManager = GameObject.Find("DownButton").GetComponent<DownButtonManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.S) || downButtonManager.downButtonPressed && cube.transform.rotation.x >= -0.20)
        {
            cubeRotateTowardsXNeg.transform.eulerAngles = new Vector3(-20, 0, cube.transform.eulerAngles.z);
            cubeRB.transform.rotation = Quaternion.RotateTowards(transform.rotation, cubeRotateTowardsXNeg.transform.rotation, 1);
        }
        if (Input.GetKey(KeyCode.W) || upButtonManager.upButtonPressed && cube.transform.rotation.x <= 0.20)
        {
            cubeRotateTowardsXPos.transform.eulerAngles = new Vector3(20, 0, cube.transform.eulerAngles.z);
            cubeRB.transform.rotation = Quaternion.RotateTowards(transform.rotation, cubeRotateTowardsXPos.transform.rotation, 1);
        }
        if (Input.GetKey(KeyCode.A) || leftButtonManager.leftButtonPressed && cube.transform.rotation.z <= 0.20)
        {
            cubeRotateTowardsZPos.transform.eulerAngles = new Vector3(cube.transform.eulerAngles.x, 0, 20);
            cubeRB.transform.rotation = Quaternion.RotateTowards(transform.rotation, cubeRotateTowardsZPos.transform.rotation, 1);
        }
        if (Input.GetKey(KeyCode.D) || rightButtonManager.rightButtonPressed && cube.transform.rotation.z >= -0.20)
        {
            cubeRotateTowardsZNeg.transform.eulerAngles = new Vector3(cube.transform.eulerAngles.x, 0, -20);
            cubeRB.transform.rotation = Quaternion.RotateTowards(transform.rotation, cubeRotateTowardsZNeg.transform.rotation, 1);
        }
    }
}
