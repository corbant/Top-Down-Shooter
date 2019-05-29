using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private int speed;
    public Transform player;
    private float sideMove;
    private float upMove;
    private ParticleSystem[] _guns;
    private AudioSource _gunNoise;
	public static Player instance;
	public bool canMove;
	public bool canShoot;
	private bool buttonDown;
	// Use this for initialization
	void Start () {
        _guns = GameObject.Find("guns").GetComponentsInChildren<ParticleSystem>();
        _gunNoise = GetComponentInChildren<AudioSource>();
		instance = this;
	}

    void OnParticleCollision(GameObject other)
    {
        if (other.name == "enemyRightGun" || other.name == "enemyLeftGun")
        {
            Destroy(player);
        }
    }

    // Update is called once per frame
    void Update () {
        Vector3 axis = new Vector3(0, 0, 0);
        sideMove = Input.GetAxis("Horizontal");
        upMove = Input.GetAxis("Vertical");
        player.rotation = new Quaternion(0,0,0,0);
		buttonDown = Input.GetButtonDown("Fire1");
		if (canShoot == false) { buttonDown = false; }
		if (canMove == false) { sideMove = 0; upMove = 0; }
        if (player.position.x >= 8.5 && sideMove > 0 || player.position.x <= -8.5 && sideMove < 0) { sideMove = 0; }
        if (player.position.y >= 4.5 && upMove > 0 || player.position.y <= -4.5 && upMove < 0) { upMove = 0; }
        player.Translate(sideMove, upMove, 0);
		
			if (buttonDown == true)
        {
            foreach (var gun in _guns) { gun.Play();}
            _gunNoise.Play();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            foreach (var gun in _guns) { gun.Stop(); }
            _gunNoise.Stop();
        }
    }

}
