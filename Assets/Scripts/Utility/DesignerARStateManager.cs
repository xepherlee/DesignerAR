using UnityEngine;
using System.Collections;

public class DesignerARStateManager{

	public enum State{
		DataInit,
		Title,
		Tutorial,
		AR,
		ModelSelect
	}

	static public void SetListenerState(State state){
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("Listener")){
			go.SendMessage(state.ToString());
		}
	}

}
