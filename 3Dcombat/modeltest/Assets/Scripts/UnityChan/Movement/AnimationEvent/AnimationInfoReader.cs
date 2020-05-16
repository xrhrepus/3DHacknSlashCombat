using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2020 05 15
/// Read anim clip progress
/// </summary>
public class AnimationInfoReader : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private float timerLimit = 10.0f;
    [SerializeField] private bool timerStop = false;
 
    IEnumerator TimerStart()
    {
        while (!timerStop && timer < timerLimit)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
    public void AIReaderStart()
    {
        timer = 0.0f;
        timerStop = false;
        StartCoroutine(TimerStart());
    }
    public void AIReaderStop()
    {
        timerStop = true;
    }
    public void AIReaderGetTime()
    {
        Debug.Log("air: " + timer);
    }
}
