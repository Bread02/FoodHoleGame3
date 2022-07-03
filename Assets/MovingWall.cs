using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void TriggerAction()
    {
        this.gameObject.transform.Translate(new Vector3(0, 0, Time.deltaTime));
        StartCoroutine(TriggerActionTime());
    }

    IEnumerator TriggerActionTime()
    {
        yield return new WaitForSeconds(5);
        completeTriggerAction = true;
    }
}
