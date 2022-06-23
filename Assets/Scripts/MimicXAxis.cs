using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicXAxis : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cube;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(cube.transform.rotation.x, 0, 0);

    }
}
