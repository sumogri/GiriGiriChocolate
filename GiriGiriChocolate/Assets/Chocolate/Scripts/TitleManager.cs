using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject tutorial;

    // Use this for initialization
    void Start () {
        StartCoroutine(First());
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private IEnumerator First()
    {
        yield return new WaitUntil(ToNext);
        tutorial.SetActive(true);
        yield return null;
        StartCoroutine(Second());
    }

    private bool ToNext()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    private IEnumerator Second()
    {
        yield return new WaitUntil(ToNext);
        SceneManager.LoadScene(sceneName);
    }
}
