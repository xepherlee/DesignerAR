using UnityEngine;
using System.Collections;

public class ButtonChangeState : MonoBehaviour {

	public DesignerARStateManager.State state;

	void OnClick(){
		DesignerARStateManager.SetListenerState (state);
	}
}
