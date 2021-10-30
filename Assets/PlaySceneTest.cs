using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySceneTest : MonoBehaviour
{
    private float time;
    private float startTime;
    public Text timing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time - startTime;
        timing.text = time*1000 + "ms";
        //Debug.Log(time);
    }
    public void Button()
    {
        startTime = Time.time;
    }

    void Notes()
    {
        
    }
}
