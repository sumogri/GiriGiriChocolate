using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TimerScript : MonoBehaviour {
    [SerializeField] private Text timer;
    [SerializeField] private float limitSeconds = 3 * 60f;
    public UnityEvent OnTimeUp;
    private float nowTime;

    // Use this for initialization
    void Start() {
        timer.text = $"{limitSeconds / 60}:{limitSeconds % 60,0:00.00}";
        nowTime = limitSeconds;
    }

    public void StartTimer()
    {
        StartCoroutine(TimerCoroutine());
    }

    public void StopTimer()
    {
        StopAllCoroutines();
    }

    public string GetTimeStr()
    {
        return $"{Mathf.FloorToInt(nowTime) / 60}:{(nowTime) % 60,0:00.00}";
    }

    private IEnumerator TimerCoroutine()
    {
        while (nowTime > 0)
        {
            yield return null;
            nowTime -= Time.deltaTime;
            timer.text = $"{Mathf.FloorToInt(nowTime) / 60}:{(nowTime) % 60,0:00.00}";
        }
        OnTimeUp.Invoke();
    }
}
