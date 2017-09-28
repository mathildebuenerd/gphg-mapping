using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageFlow : MonoBehaviour {

    [Range(0.0f, 50.0f)]
    public float quantite;

    [Range(0.0f, 10.0f)]
    public float diametre;

    [Range(0.0f, 1.0f)]
    public float red;
    [Range(0.0f, 1.0f)]
    public float green;
    [Range(0.0f, 1.0f)]
    public float blue;
    [Range(0.0f, 1.0f)]
    public float alpha;

    [Range(0.0f, 1.0f)]
    public float redTrail;
    [Range(0.0f, 1.0f)]
    public float greenTrail;
    [Range(0.0f, 1.0f)]
    public float blueTrail;
    [Range(0.0f, 1.0f)]
    public float alphaTrail;

    ParticleSystem ps;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
       // color = new Vector3(red,green,blue);
    }

    private void Update()
    {

        var emission = ps.emission;
        var main = ps.main;
        var trails = ps.trails;

        
        emission.rateOverTime = quantite;
        main.startColor = new Color(red, green, blue, alpha);
        trails.colorOverTrail = new Color(redTrail, greenTrail, blueTrail, alphaTrail);

        //ps.GetComponent<Renderer>.


    }


}
