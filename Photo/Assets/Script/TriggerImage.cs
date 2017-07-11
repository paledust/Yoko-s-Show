using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Change_Photo_Event = MyEvent.Change_Photo_Event;
public class TriggerImage : MonoBehaviour {
	[SerializeField] List<Sprite> photos;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.name == "Card"){
			if(collider.transform.rotation.eulerAngles.z <= 90 || collider.transform.rotation.eulerAngles.z >= 270){
				Change_Photo_Event tempEvent = new Change_Photo_Event(photos[Random.Range(0,photos.Count)]);
				Server.eventManager.FireEvent(tempEvent);
				GetComponentInParent<AudioSource>().pitch = 1.0f;
				GetComponentInParent<AudioSource>().volume = 0.6f;
				GetComponentInParent<AudioSource>().PlayOneShot(Server.prefeb.Groan[Random.Range(0, Server.prefeb.Groan.Count)]);
			}
			else{
				Change_Photo_Event tempEvent = new Change_Photo_Event(Server.prefeb.Photos[3]);
				Server.eventManager.FireEvent(tempEvent);
			}
		}
	}
	void OnTriggerExit2D(Collider2D collider){
		if(collider.name == "Card"){
			Change_Photo_Event tempEvent = new Change_Photo_Event(null);
			Server.eventManager.FireEvent(tempEvent);
		}
	}
}
