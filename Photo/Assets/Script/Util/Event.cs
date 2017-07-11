using Sprite = UnityEngine.Sprite;
namespace MyEvent
{
	public abstract class Event {
		public delegate void handler(Event e);
	}
	public class Change_Photo_Event: Event{
		private Sprite photo;
		public Sprite Photo{get{return photo;}}
		public Change_Photo_Event(Sprite _photo){
			photo = _photo;
		}
	}
}
