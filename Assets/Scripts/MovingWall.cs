using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingWall : MonoBehaviour
{
    public bool triggered;
    public bool completeTriggerAction;


    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered && !completeTriggerAction)
        {
            TriggerAction();
        }
    }

    // the trigger action depends on the level, specify what you want the trigger action to do in different levels.
    public void TriggerAction()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level29")
        {
            this.gameObject.transform.Translate(new Vector3(Time.deltaTime, 0, 0));
            StartCoroutine(TriggerActionTime());
        }
        if (scene.name == "Level9")
        {
            this.gameObject.transform.Translate(new Vector3(0, 0, Time.deltaTime));
            StartCoroutine(TriggerActionTime());
        }
    }

    IEnumerator TriggerActionTime()
    {
        yield return new WaitForSeconds(5);
        completeTriggerAction = true;
    }
}
