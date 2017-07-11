using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour {
	public enum MAT_Type{
		Glass,
		Wood
	}
	[SerializeField] MAT_Type material;
	[SerializeField] float MainPitch;
	[SerializeField] float OffPitch;
	AudioSource audioSource; 
	// Use this for initialization
	void Start () {
		gameObject.AddComponent<AudioSource>();
		audioSource = GetComponent<AudioSource>();
		audioSource.pitch = MainPitch;
	}
	void OnCollisionEnter2D(Collision2D collision){
		switch (material)
		{
			case MAT_Type.Wood:
				audioSource.pitch = MainPitch + Random.Range(-OffPitch, OffPitch);
				audioSource.PlayOneShot(Server.wood);
				break;
			case MAT_Type.Glass:
				audioSource.pitch = MainPitch + Random.Range(-OffPitch, OffPitch);
				audioSource.PlayOneShot(Server.glass);
				break;
			default:
				break;
		}
	}

}
