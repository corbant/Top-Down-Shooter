using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public bool isDialogueShowing;
	public string playerName;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        instance = this;
		playerName = "";
		Player.instance.canMove = true;
		Player.instance.canShoot = true;
        //GameObject.Find("Test").GetComponent<Dialogue>().Run();
		//GameObject.Find("LevelComplete").SetActive(true);
		//GameObject.Find("Stars").GetComponent<ParticleSystem>().playbackSpeed = 5;
		//GameObject.Find("Stars").GetComponentInChildren<ParticleSystem>().playbackSpeed = 5;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
