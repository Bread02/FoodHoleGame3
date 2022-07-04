using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSaladController : MonoBehaviour
{
    public GameObject fruitSalad;

    public bool fruitSaladAt0;
    public bool fruitSaladGoUpMore;

    // Start is called before the first frame update
    void Start()
    {
        fruitSaladAt0 = false;
    }

    // Update is called once per frame
    void Update()
    {
        FruitSaladTrigger();
    }

    public void FruitSaladTrigger()
    {
        if (fruitSalad.transform.position.y != 0)
        {
            fruitSalad.transform.Translate(0, 300 * Time.deltaTime, 0);
        }
     
    }
}
