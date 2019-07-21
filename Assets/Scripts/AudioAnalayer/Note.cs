
using System;


[Serializable]
public class Note
{
	private int pitch;  
	private float time; 

	public int Pitch {
		get {
			return this.pitch;
		}
		set {
			pitch = value;
		}
	}
			
	public float Time {
		get {
			return this.time;
		}
		set {
			time = value;
		}
	}

	public Note (int pitch, float time)
	{
		this.pitch = pitch; 
		this.time = time; 
	}

}


