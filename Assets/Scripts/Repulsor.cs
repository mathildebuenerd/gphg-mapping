using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repulsor : MonoBehaviour {

    // Repulsor
    public bool attractAllParticles;
    public ParticleSystem my_system;
    public GameObject repulsor;

    public Vector3 attractorPosition;

    public float angle = 0.3f;
    public float factor = 0.1f;

    [Range(0.0f, 1.5f)]
    public float smoothTime = 0.2f;

    float sqrDist;

    // Use this for initialization
    void Start () {

        // initialize particle attractor
        attractorPosition = repulsor.transform.position;

    }
	
	// Update is called once per frame
	void Update () {

        repulsor.transform.position = attractorPosition;

        if (attractAllParticles)
        {
            RepulseParticles();
        }

    }

    void RepulseParticles()
    {

        ParticleSystem.Particle[] my_particles = new ParticleSystem.Particle[my_system.particleCount];

        int numParticles = my_system.GetParticles(my_particles);

        Vector3 targetPosition = repulsor.transform.position;
        Vector3 velocity = Vector3.zero;

        Vector3 direction = new Vector3(Random.Range(-0.1f, 0.1f), 0.0f, Random.Range(-0.1f, 0.1f));

        for (int i = 0; i < numParticles; i++)
        {
            Vector3 currentPosition = my_particles[i].position;

            float dirX = direction.z + angle + Mathf.Cos(factor);
            float dirZ = direction.x + angle + Mathf.Sin(factor);

            Vector3 newPosition = new Vector3(dirX, dirZ, 0.0f);

            my_particles[i].position = Vector3.SmoothDamp(currentPosition, newPosition, ref velocity, smoothTime);
            //my_particles[i].position += newPosition;

            factor += Random.Range(-0.01f, 0.01f);

        }

        my_system.SetParticles(my_particles, my_system.particleCount);
    }
}
