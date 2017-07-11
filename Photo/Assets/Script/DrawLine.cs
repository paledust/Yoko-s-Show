using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {
	RopeManager ropeManager;
	List<GameObject> Anchors;
	LineRenderer lineRender;
	// Use this for initialization
	void Start () {
		ropeManager = GameObject.Find("RopeManager").GetComponent<RopeManager>();
		Anchors = ropeManager.Anchor;
		lineRender = GetComponent<LineRenderer>();
		lineRender.positionCount = ropeManager.AnchorCount;
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < lineRender.positionCount; i++){
			lineRender.SetPosition(i, Anchors[i].transform.position);
		}
	}
}
