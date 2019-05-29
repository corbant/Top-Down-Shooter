using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class enemyShips : MonoBehaviour
{
    private ParticleSystem[] _guns;
    private Vector3 playerPos;
    public GameObject enemy;
    private bool active = false;

	void OnParticleCollision(GameObject other)
	{
         if(active == true && (other.name == "rightGun" || other.name == "leftGun"))
        {
            Destroy(enemy);
        }
	}

	void OnCollisionEnter2D(Collision2D player)
	{
		if (active == true && player.gameObject.name == "Player")
		{
			Destroy(enemy);
		}
	}

	// Use this for initialization
	void Start()
    {
        _guns = GetComponentsInChildren<ParticleSystem>();
        Rigidbody2D hit = enemy.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //activate
        if (active == false)
        {
            if (enemy.transform.position.y <= 6)
            {
                active = true;
                transform.SetParent(null, true); //remove from scroller

                //enable things one time

                //enable guns
                foreach (var gun in _guns)
                {
                    gun.Play();
                }
            }
            return;
        }

        //destroy if it goes off screen
		if (enemy.transform.position.y <= -7) { Destroy(enemy); }

        //activate movement
        enemy.transform.Translate(0, 0.05f, 0);

    }
}
