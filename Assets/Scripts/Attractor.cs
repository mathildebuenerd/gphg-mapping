using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {

    // Attracter
    public bool attractAllParticles;
    public ParticleSystem my_system;
    public GameObject attractor;
    public GameObject[] attractors;


    public Vector3 attractorPosition;
    public float affectDistance;

    [Range(0.0f, 1.0f)]
    public float smoothTime = 0.5f; // si proche de 0 l'attractivité est très forte, si proche de 1 elle est faible
    public float quantity = 10.0f;

    float sqrDist;



    private void Start()
    {
        // initialize particle attractor
        sqrDist = affectDistance * affectDistance;
        attractorPosition = attractor.transform.position;
    }


    void Update () {

        //  my_system.GetComponent<ParticleSystem>().emission.rateOverTime = quantity;

        attractor.transform.position = attractorPosition;

        if (attractAllParticles)
        {
            AttractParticles();
        }

    }

    // Attract les particules
    void AttractParticles()
    {

        ParticleSystem.Particle[] my_particles = new ParticleSystem.Particle[my_system.particleCount];

        int numParticles = my_system.GetParticles(my_particles);

        Debug.Log("Il y a " + numParticles + " particules");

        Vector3 targetPosition = attractor.transform.position;
        Vector3 velocity = Vector3.zero;

        for (int i = 0; i < numParticles; i++)
        {
            Vector3 currentPosition = my_particles[i].position;
            my_particles[i].position = Vector3.SmoothDamp(currentPosition, targetPosition, ref velocity, smoothTime);
            
        }

        my_system.SetParticles(my_particles, my_system.particleCount);

    }
}
