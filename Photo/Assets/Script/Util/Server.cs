using UnityEngine;
public static class Server{
	public static PrefebList prefeb = Resources.Load<PrefebList>("PrefebList");
	public static EventManager eventManager = new EventManager();
	public static AudioClip glass = Resources.Load<AudioClip>("Sound/glass");
	public static AudioClip wood = Resources.Load<AudioClip>("Sound/wood");
}
