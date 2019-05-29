using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Stars : MonoBehaviour {
    public static Stars instance;
    public float speed;

	// Use this for initialization
	void Start () {
        instance = this;
        speed = 1;
	}
	
	// Update is called once per frame
	void Update () {
        var p = GetComponent<ParticleSystem>();
        var ps = GetComponentsInChildren<ParticleSystem>();
        p.playbackSpeed = speed;
        foreach (var p2 in ps)
            p2.playbackSpeed = speed;
    }
}
