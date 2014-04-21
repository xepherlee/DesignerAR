using UnityEngine;
using System.Collections;

public class TutorialUIController : DesinerARBehaviour {

	public UICenterOnChild tutorialCenterOnChild;

	void Start(){
		if(tutorialCenterOnChild != null){
			tutorialCenterOnChild.onFinished = OnTutorialPageChanged;
		}
	}

	void OnTutorialPageChanged(){
		Debug.Log (tutorialCenterOnChild.centeredObject.name);
		if(tutorialCenterOnChild.centeredObject.name != "pend"){
			
		}
		else{
			DesignerARStateManager.SetListenerState(DesignerARStateManager.State.AR);
		}
	}

	public override void Tutorial ()
	{
		base.Tutorial ();
		SetAllChildActive (true);
	}

	public override void AR ()
	{
		base.AR ();
		SetAllChildActive (false);
	}

	public override void DataInit ()
	{
		base.DataInit ();
		SetAllChildActive (false);
	}

	public override void ModelSelect ()
	{
		base.ModelSelect ();
		SetAllChildActive (false);
	}

	public override void Title ()
	{
		base.Title ();
		SetAllChildActive (false);
	}
}
