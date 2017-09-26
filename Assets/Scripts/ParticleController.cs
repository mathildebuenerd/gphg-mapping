using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

	// GameObjects
	public GameObject MyParticleSystem;
	public Material[] materials;
	private List<GameObject> AllParticleSystems;

	// Prefabs
	public GameObject ParticleSystem0;

	// Controllers
	public bool increaseRate;
	public bool changeColor;
	public bool addNewParticleSystem;

	// Variables
	private float sceneWidth = 100.0f; // A ajuster en fonction de la taille finale que l'on souhaite
	private float sceneHeight = 40.0f;
	private float quantity;


	void Start() {
		
		List<GameObject> AllParticleSystems = new List<GameObject>();
		AllParticleSystems.Add (ParticleSystem0);
		Debug.Log (AllParticleSystems[0]);

	}

	void Update() {
		checkConditions ();
	}

	void ApplyOnOneParticleSystem() {

	}

	public GameObject[] ApplyOnAllParticles() {

		GameObject[] listOfParticleSystems;
		listOfParticleSystems = GameObject.FindGameObjectsWithTag ("particlesystem");

		return listOfParticleSystems;

	}

	void AddNewParticleSystem() {

		// on choisit une position au hasard dans la scene
		float posX = Random.value*(sceneWidth-(-sceneWidth))-sceneWidth;
		float posZ = Random.value*(sceneHeight-(-sceneHeight))-sceneHeight;;
//		Debug.Log (posX);
		GameObject NewParticleSystem = Instantiate (ParticleSystem0);
		Vector3 initPosition = NewParticleSystem.transform.position;
		initPosition.x = posX;
		initPosition.z = posZ;
		NewParticleSystem.transform.position = initPosition;
	}
		

	// la couleur pourrait changer de manière smooth en n'utilisant qu'un material mais en jouant sur sa teinte
	public void ChangeColor(string color) {

		if (color == "blue") {
			MyParticleSystem.GetComponent<ParticleSystemRenderer> ().material = materials [0];
		} else if (color == "white") {
			MyParticleSystem.GetComponent<ParticleSystemRenderer> ().material = materials [1];
		}
	}

	public void IncreaseRate() {
	
	}

	private void checkConditions() {

		if (increaseRate) {
			IncreaseRate ();
		}

		if (changeColor) {
			ChangeColor ("blue");
		} 

		if (changeColor==false) {
			ChangeColor("white");
		}

		if (addNewParticleSystem) {
			AddNewParticleSystem ();
			addNewParticleSystem = false;
		}

	}

}