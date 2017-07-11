using System;
using System.Collections.Generic;
using MyEvent;

public class EventManager {
	static private EventManager instance;
	static public EventManager Instance{get{
		if(instance == null)
			instance = new EventManager();
		return instance;
	}}
	private Dictionary<Type, Event.handler> registed_handlers = new Dictionary<Type, Event.handler>();

	public void RegistHandler<T>(Event.handler handler) where T: Event{
		Type type = typeof(T);
		if(registed_handlers.ContainsKey(type)){
			registed_handlers[type] += handler;
		}
		else{
			registed_handlers[type] = handler;
		}
	}
	public void UnregistHandler<T>(Event.handler handler) where T: Event{
		Type type = typeof(T);
		Event.handler handlers;
		if(registed_handlers.TryGetValue(type, out handlers)){
			handlers -= handler;
			if(handlers == null){
				registed_handlers.Remove(type);
			}
			else{
				registed_handlers[type] = handlers;
			}
		}
	}
	public void FireEvent(Event e){
		Type type = e.GetType();
		Event.handler handlers;

		if(registed_handlers.TryGetValue(type, out handlers))
			handlers(e);
	}
	public void ClearList(){
		registed_handlers.Clear();
	}
}
