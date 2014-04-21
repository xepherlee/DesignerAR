using UnityEngine;
using System.Collections;

public class MarkerController : DesinerARBehaviour {

	public int markerID;
	public DetailPanelController detailPanelController;

	private ModelController modelController;

	public override void AR ()
	{
		base.AR ();
		SetAllChildActive (true);

		if(modelController == null){
			InstantiateModelFromResource(GlobalObject.GetDesignerAR().GetNowModel(markerID));
		}
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
	
	public override void Tutorial ()
	{
		base.Tutorial ();
		SetAllChildActive (false);
	}

	public void OpenModelDetailPanel(ModelItem modelItem){
		detailPanelController.Init(modelItem, markerID);
	}

	void InstantiateModelFromResource(ModelItem modelItem){
		GameObject prefab = Resources.Load ("ModelPrefabs/" + modelItem.filename, typeof(GameObject)) as GameObject;
		if(prefab != null){
			GameObject go = GameObject.Instantiate (prefab) as GameObject;
			go.name = modelItem.filename;
			go.transform.parent = this.transform;
			go.transform.localPosition = Vector3.zero;
			go.AddComponent<BoxCollider>();
			modelController = go.AddComponent<ModelController> ();
			modelController.Init (modelItem);
		}
	}

}
