using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSelect : MonoBehaviour {
	Ray mouseRay;
	RaycastHit2D hit;
	RopeAnchor anchor;
	[SerializeField] LayerMask layer;

	// Use this for initialization
	void Start () {
		layer = LayerMask.GetMask("DragRope");
	}
	void Update(){
		mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Input.GetMouseButtonDown(0)){
			hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction, 100, layer);

			if(hit){
				Debug.Log("Hit" + hit.collider.gameObject.ToString());
				anchor = hit.collider.GetComponent<RopeAnchor>();
				anchor.Dragged();
			}
		}
		if(Input.GetMouseButtonUp(0) && anchor != null){
			anchor.Release();
		}
		Debug.DrawLine(mouseRay.origin, mouseRay.direction * 100 + mouseRay.origin);
	}
}
