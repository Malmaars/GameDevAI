using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeTimer : MonoBehaviour
{
    float timerLimit = 0;
    // Update is called once per frame
    void Update()
    {
        timerLimit += Time.deltaTime;
        
        if(timerLimit > 5f)
        {
            Destroy(this.gameObject);
        }
    }
}
