using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager> {
    [SerializeField] private GameObject[] prefabs;
    public GameObject[] StagePrefabs { get { return prefabs; } }
    [SerializeField] private TimerScript timer;
    public TimerScript Timer { get { return timer; } }
    [SerializeField] private Text CountDown;
    private float time = 3f;
    public UnityEvent OnGameStart;
    public static string ClearTime;

	// Use this for initialization
	void Start () {
        StartCoroutine(OnStartCount());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameClear()
    {
        timer.StopTimer();
        ClearTime = timer.GetTimeStr();
        SceneManager.LoadScene("Clear");
    }

    private IEnumerator OnStartCount()
    {
        while (time > 0)
        {
            CountDown.text = $"{time}";
            yield return new WaitForSecondsRealtime(1f);
            time--;
        }
        CountDown.text = "Go!";
        timer.StartTimer();
        OnGameStart.Invoke();
        yield return new WaitForSecondsRealtime(1f);
        Destroy(CountDown.gameObject);
    }
}
