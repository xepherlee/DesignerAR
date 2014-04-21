using UnityEngine;
using System.Collections;

public class ModelController : MonoBehaviour {

	private ModelItem modelItem;

	public void Init(ModelItem modelItem){
		if(this.modelItem == null){
			this.modelItem = modelItem;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(modelItem != null){
			this.transform.localScale = modelItem.scaling_factor / this.transform.parent.localScale.x;
			this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x,modelItem.rotate_angle,this.transform.localEulerAngles.z);
		}
	}

	void OnClick(){
		if(modelItem != null){
			this.SendMessageUpwards("OpenModelDetailPanel",modelItem);
		}
	}
}
