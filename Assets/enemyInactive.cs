using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyInactive : MonoBehaviour {
    public Transform enemies;


    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.isDialogueShowing == false)
        {
            enemies.transform.Translate(0, -0.005f, 0);
        }
    }
}
