using UnityEngine;
using System.Collections;

public class SpecialEffectsHelper : MonoBehaviour {
	public static SpecialEffectsHelper Instance;

	public ParticleSystem ghostEffectDown;
	public ParticleSystem ghostEffectUp;
	public ParticleSystem ghostEffectRight;
	public ParticleSystem ghostEffectLeft;
	public ParticleSystem fireEffect;

	void Awake()
	{
		// On garde une référence du singleton
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of SpecialEffectsHelper!");
		}

		Instance = this;
	}

	/// <summary>
	/// Création d'une explosion à l'endroit indiqué
	/// </summary>
	/// <param name="position"></param>
	public void Ghost(Vector3 position,int direction)
	{
		// Smoke on the water
		if( direction == 2)
		instantiate(ghostEffectDown, position);
		if( direction == 8)
			instantiate(ghostEffectUp, position);
		if( direction == 4)
			instantiate(ghostEffectLeft, position);
		if( direction == 6)
			instantiate(ghostEffectRight, position);

		if( direction == 1)
			instantiate(ghostEffectDown, position);
		if( direction == 9)
			instantiate(ghostEffectUp, position);
		if( direction == 7)
			instantiate(ghostEffectLeft, position);
		if( direction == 3)
			instantiate(ghostEffectRight, position);
	}


	public ParticleSystem Explosion(Vector3 position){
		
		return instantiate(fireEffect, position);
	
	}



	/// <summary>
	/// Création d'un effet de particule depuis un prefab
	/// </summary>
	/// <param name="prefab"></param>
	/// <returns></returns>
	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
	{
		ParticleSystem newParticleSystem = Instantiate(
			prefab,
			position,
			Quaternion.identity
		) as ParticleSystem;

		// Destruction programmée
		Destroy(
			newParticleSystem.gameObject,
			5f
		);

		return newParticleSystem;
	}
}
