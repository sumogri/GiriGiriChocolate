using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {
    private UnityChanControlScriptWithRgidBody kohakuController;

	// Use this for initialization
	void Start () {
        kohakuController = gameObject.GetComponent<UnityChanControlScriptWithRgidBody>();
        kohakuController.enabled = false;
        GameManager.I.OnGameStart.AddListener(OnGameStart);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGameStart()
    {
        kohakuController.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Goal")
        {
            GameManager.I.GameClear();
        }
    }
}
