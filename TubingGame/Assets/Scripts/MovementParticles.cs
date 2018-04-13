using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementParticles : MonoBehaviour
{
	//Player
	private Rigidbody2D rb;
	private float playerVelocity;
	private SpriteRenderer playerSprite;
	public Color playerColor;

	//Particle Components
	private GameObject pSpawn1;
	private GameObject pSpawn2;
	private ParticleSystem pSystem1;
	private ParticleSystem pSystem2;

	//Particle Variables
	public int particleSpawns = 10;
	public int baseParticles = 5;
    public bool coloredTrail = true;
	

	private void Start()
	{
		//Populate player components
		rb = this.GetComponent<Rigidbody2D>();
		playerSprite = this.GetComponent<SpriteRenderer>();
		playerColor = playerSprite.color;

		//Populate components
		pSpawn1 = this.transform.Find("ParticleSpawn1").gameObject;
		pSpawn2 = this.transform.Find("ParticleSpawn2").gameObject;
		pSystem1 = pSpawn1.GetComponent<ParticleSystem>();
		pSystem2 = pSpawn2.GetComponent<ParticleSystem>();

		//Particle System Colors, disable for normal blue
		if (coloredTrail)
        {
            var pMain1 = pSystem1.main;
            var pMain2 = pSystem2.main;
            pMain1.startColor = playerColor;
            pMain2.startColor = playerColor;
        }
	}

	private void Update()
	{
		//Get player velocity as float
		playerVelocity = rb.velocity.magnitude;

		//Define emissions as local variable
		var emission1 = pSystem1.emission;
		var emission2 = pSystem2.emission;

		//Change emission rate to reflect player speed
		emission1.rateOverTime = playerVelocity * Mathf.Floor(particleSpawns) + baseParticles;
		emission2.rateOverTime = playerVelocity * Mathf.Floor(particleSpawns) + baseParticles;
	}

}
