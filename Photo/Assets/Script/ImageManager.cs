using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Change_Photo_Event = MyEvent.Change_Photo_Event;

public enum FrameState{
	APPEARED,
	DISAPPEARING,
	DISAPPEARED,
	APPEARING
}
public class ImageManager : MonoBehaviour {
	[SerializeField] FrameState state; 
	[SerializeField] Sprite photo_2;
	public Sprite Photo_2{get{return photo_2;}}
	SpriteRenderer spriteRender;
	
	void Start(){
		spriteRender = GetComponent<SpriteRenderer>();
		spriteRender.color = new Color(1,1,1,0);
		Server.eventManager.RegistHandler<Change_Photo_Event>(SetPhoto);
		state = FrameState.DISAPPEARED;
	}
	// Update is called once per frame
	void Update () {
		switch (state)
		{
			case FrameState.APPEARED:
				APP_Update();
				break;
			case FrameState.DISAPPEARING:
				DISING_Update();
				break;
			case FrameState.DISAPPEARED:
				DIS_Update();
				break;
			case FrameState.APPEARING:
				APPING_Update();
				break;
			default:
				break;
		}
	}
	public void SetPhoto(MyEvent.Event e){
		Change_Photo_Event tempEvent = e as Change_Photo_Event;
		if(tempEvent.Photo != spriteRender.sprite){
			photo_2 = tempEvent.Photo;
			SetState(FrameState.DISAPPEARING);
		}
	}
	public void SetState(FrameState m_state){
		state = m_state;
	}

	private void APP_Update(){
		if(spriteRender.sprite != photo_2){
			state = FrameState.DISAPPEARING;
		}
	}
	private void DIS_Update(){
		if(spriteRender.color.a != 0){
			spriteRender.color = new Color(1,1,1,0);
		}

		if(photo_2 != null){
			spriteRender.sprite = photo_2;
			state = FrameState.APPEARING;
		}
	}
	private void DISING_Update(){
		spriteRender.color = Color.Lerp(spriteRender.color, new Color(1,1,1,0), Time.deltaTime * 10.0f);
		if(spriteRender.color.a <= 0.05f){
			spriteRender.color = new Color(1,1,1,0);
			spriteRender.sprite = null;
			state = FrameState.DISAPPEARED;
		}
	}
	private void APPING_Update(){
		spriteRender.color = Color.Lerp(spriteRender.color, Color.white, Time.deltaTime * 10.0f);
		if(spriteRender.color.a >= 0.95f){
			spriteRender.color = Color.white;
			state = FrameState.APPEARED;
		}
	}

}
