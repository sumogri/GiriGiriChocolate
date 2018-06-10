using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// タイマでシーンを繊維する
/// </summary>
public class SceneLoadTimer : MonoBehaviour {
    [SerializeField] private string sceneName;

	// Use this for initialization
	void Start () {

	}

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
