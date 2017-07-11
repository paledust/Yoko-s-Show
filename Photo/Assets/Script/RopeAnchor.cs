using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeAnchor : MonoBehaviour {
	Rigidbody2D _rigidbody2D;
	bool _isDragged;
	void Start(){
		_isDragged = false;
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}
	public void Dragged(){
		_isDragged = true;
		_rigidbody2D.isKinematic = true;
		_rigidbody2D.freezeRotation = true;
	}
	public void Release(){
		_isDragged = false;
		_rigidbody2D.isKinematic = false;
		_rigidbody2D.freezeRotation = false;
	}
	void Update(){
		if(_isDragged){
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePos = new Vector3(mousePos.x, mousePos.y, transform.position.z);
			transform.position = Vector3.Lerp(transform.position, mousePos, Time.deltaTime * 100);
		}
	}
}
