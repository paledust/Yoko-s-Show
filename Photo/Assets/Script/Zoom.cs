using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {
	[SerializeField] int index = 0;
	public int Index{get{return index;}}
	// Use this for initialization
	void Start () {
		GetComponentInChildren<Camera>().targetTexture = Resources.Load<RenderTexture>("TargetTex/Zoom" + index.ToString());
		transform.FindChild("ZoomerPlane").GetComponent<Renderer>().material.mainTexture = Resources.Load<RenderTexture>("TargetTex/Zoom" + index.ToString());
	}
}
