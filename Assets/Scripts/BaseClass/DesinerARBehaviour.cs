using UnityEngine;
using System.Collections;

public class DesinerARBehaviour : MonoBehaviour,IDesinerARState {

	protected DesignerARStateManager.State state;

	virtual public void DataInit(){
		state = DesignerARStateManager.State.DataInit;
	}

	virtual public void Title(){
		state = DesignerARStateManager.State.Title;
	}

	virtual public void AR(){
		state = DesignerARStateManager.State.AR;
	}

	virtual public void ModelSelect(){
		state = DesignerARStateManager.State.ModelSelect;
	}

	virtual public void Tutorial(){
		state = DesignerARStateManager.State.Tutorial;
	}

	public void SetAllChildActive(bool isActive){
		foreach(Transform trs in this.transform){
			trs.gameObject.SetActive(isActive);
		}
	}
}
