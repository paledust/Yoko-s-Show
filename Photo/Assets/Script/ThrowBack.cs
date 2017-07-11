using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBack : MonoBehaviour {
	[SerializeField] float height_Limit = -60.0f;
	GameObject card;
	GameObject RopeManager;
	void Start(){
		card = GameObject.Find("Card");
		RopeManager = GameObject.Find("RopeManager");
	}
	// Update is called once per frame
	void Update () {
		if(card.transform.position.y < height_Limit){
			Vector3 pos = card.transform.position;
			Mathf.Clamp(pos.x,-90,90);
			pos.y = 46;
			card.transform.position = pos;
			card.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			RopeManager.GetComponent<RopeManager>().ResetAnchor();
			card.GetComponent<Rigidbody2D>().AddForce(-card.transform.position*3, ForceMode2D.Impulse);
		}
	}
}
