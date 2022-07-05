using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FruitSaladController : MonoBehaviour
{
    public GameObject fruitSalad;

    public bool fruitSaladAt0;
    public bool fruitSaladGoUpMore;

    public bool fruitSaladTrigger;

    // Start is called before the first frame update
    void Start()
    {
        fruitSaladTrigger = false;
        fruitSalad.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (fruitSaladTrigger)
        {
            FruitSaladTrigger();
        }
    }

    public void FruitSaladTrigger()
    {
        Scene scene = SceneManager.GetActiveScene();
        switch (scene.name)
        {
            case "Level17":
                fruitSalad.SetActive(true);
                break;
            case "Level26":
                fruitSalad.SetActive(true);
                break;
            default: fruitSalad.SetActive(false);
                break;

        }
    }
}
