using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "PrefebList")]
public class PrefebList : ScriptableObject {
	[SerializeField] GameObject _Anchor;
	public GameObject Anchor{get{return _Anchor;}}
	[SerializeField] GameObject _Anchor_End;
	public GameObject Anchor_End{get{return _Anchor_End;}}
	[SerializeField] GameObject _Frame;
	public GameObject Frame{get{return _Frame;}}
	[SerializeField] List<Sprite> _Photos;
	public List<Sprite> Photos{get{return _Photos;}}
	[SerializeField] List<AudioClip> groan;
	public List<AudioClip> Groan{get{return groan;}}
}
