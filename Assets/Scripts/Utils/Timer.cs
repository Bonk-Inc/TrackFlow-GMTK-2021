using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float time = 0;

    private bool pause = false;

    public bool Pause
    {
        get { return pause; }
        set { pause = value; }
    }

    public float CurrentTime => time;

    private void FixedUpdate()
    {
        if (pause) return;
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        time += Time.fixedDeltaTime;
    }

    public void ResetTime()
    {
        time = 0;
    }
}
