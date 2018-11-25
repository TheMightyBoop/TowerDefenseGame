using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

    public ParticleSystem particles;
    public float PauseTime = 0f;

    void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad > PauseTime)
        {
            particles.Pause();
        }
	}
}
