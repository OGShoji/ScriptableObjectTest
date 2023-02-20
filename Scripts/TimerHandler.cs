using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Variable;
public class TimerHandler : MonoBehaviour
{
    public Float timer;
    public bool isCountDown;
    // Start is called before the first frame update
    void Start()
    {
        timer.RuntimeValue = timer.InitialValue;
    }

    // Update is called once per frame
    void Update()
    {
        if(isCountDown)
        {
            if(timer.RuntimeValue >= 0)
            {
                timer.RuntimeValue -= Time.deltaTime;
            }
        }
        else
        {
            timer.RuntimeValue += Time.deltaTime;
        }
    }
}
