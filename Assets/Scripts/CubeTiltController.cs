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

    private Image upButton;
    private Image leftButton;
    private Image rightButton;
    private Image downButton;

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

        upButton = GameObject.Find("UpButton").GetComponent<Image>();
        rightButton = GameObject.Find("RightButton").GetComponent<Image>();
        leftButton = GameObject.Find("LeftButton").GetComponent<Image>();
        downButton = GameObject.Find("DownButton").GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        if (cube.transform.rotation.x >= -0.17)
        {
            downButton.color = readyColor;
            Debug.Log("Ready");
        }
        else
        {
            downButton.color = cannotUseColor;
            Debug.Log("Not Ready");
        }

        if (cube.transform.rotation.x <= 0.17)
        {
            upButton.color = readyColor;
            Debug.Log(cube.transform.rotation.x);

        }
        else
        {
            upButton.color = cannotUseColor;
            Debug.Log(cube.transform.rotation.x);

        }

        if (cube.transform.rotation.z <= 0.17)
        {
            leftButton.color = readyColor;
        }
        else
        {
            leftButton.color = cannotUseColor;
        }

        if (cube.transform.rotation.z >= -0.17)
        {
            rightButton.color = readyColor;
        }
        else
        {
            rightButton.color = cannotUseColor;
        }

        */

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
