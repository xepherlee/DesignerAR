using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DesignerAR{
	public List<Company> company;
	public string link;
	public List<Model> model;
	public string version;
	public string showmodel1;
	public string showmodel2;
	public ModelItem[] nowModels;

	public DesignerAR(){
		nowModels = new ModelItem[2];
	}

	public List<Model> GetModelData(){
		return model;
	}

	public List<Company> GetCompanyData(){
		return company;
	}

	public ModelItem GetNowModel(int markerID){
		if(nowModels[markerID] == null){
			if(markerID == 0){
				nowModels[markerID] = new ModelItem(model.Find(m => m.filename == showmodel1));
			}
			else{
				nowModels[markerID] = new ModelItem(model.Find(m => m.filename == showmodel2));
			}
		}
		return nowModels [markerID];
	}
}
