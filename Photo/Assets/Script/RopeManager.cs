using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeManager : MonoBehaviour {
	[SerializeField] List<GameObject> _Anchors;
	public List<GameObject> Anchor{get{return _Anchors;}}
	[SerializeField] int _AnchorCount;
	public int AnchorCount{get{return _AnchorCount;}}
	[SerializeField] float Length;
	[SerializeField] Transform StartPoint;
	// Use this for initialization
	void Awake () {
		float pause = Length/(_AnchorCount-1);
		for(int i = 0; i<_AnchorCount; i++){
			GameObject Anchor = Instantiate(Server.prefeb.Anchor, StartPoint.position + i * Vector3.up * pause + Vector3.forward * -0.5f, default(Quaternion));
			_Anchors.Add(Anchor);
			if(i == 0){
				Anchor.GetComponent<FixedJoint2D>().connectedBody = GameObject.Find("Card").GetComponent<Rigidbody2D>();
				Anchor.GetComponent<FixedJoint2D>().connectedAnchor = Vector2.up * 10;
			}
			else
				Anchor.GetComponent<FixedJoint2D>().connectedBody = _Anchors[i-1].GetComponent<Rigidbody2D>();
			
			if(i == _AnchorCount - 1){
				// Anchor.GetComponent<Rigidbody2D>().isKinematic = true;
				Anchor.layer = LayerMask.NameToLayer("DragRope");
				Anchor.AddComponent<CircleCollider2D>();
				Anchor.AddComponent<RopeAnchor>();
				Anchor.GetComponent<CircleCollider2D>().radius = 5;
				Anchor.GetComponent<CircleCollider2D>().isTrigger = true;
				Anchor.GetComponent<Rigidbody2D>().isKinematic = true;
				Anchor.transform.position = new Vector3(GameObject.Find("pin").transform.position.x, GameObject.Find("pin").transform.position.y,transform.position.z);
				Anchor.AddComponent<RopeSelect>();
			}
		}
	}
	public void ResetAnchor(){
		for(int i = 0; i < Anchor.Count; i ++){
			if(i!=0)
				Anchor[i].transform.position = Anchor[i-1].transform.position + Vector3.up;
			else
				Anchor[i].transform.position = GameObject.Find("Card").transform.position + Vector3.up * 10;

			Anchor[i].GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		}
	}
}
