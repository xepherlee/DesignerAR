using UnityEngine;
using System.Collections;

public class Model{
	public string category;
	public string company;
	public string filename;
	public double height;
	public double length;
	public double width;
	public string link;
	public string name;
	public string order;
	public bool show;
	public double size;

	public Model(Model model){
		this.category = model.category;
		this.company = model.company;
		this.filename = model.filename;
		this.height = model.height;
		this.length = model.length;
		this.width = model.width;
		this.link = model.link;
		this.name = model.name;
		this.order = model.order;
		this.show = model.show;
		this.size = model.size;
	}

	public Model(){

	}
}

public class ModelItem:Model{
	public Vector3 scaling_factor;
	public float rotate_angle;

	public ModelItem(Model model):base(model){
		scaling_factor = Vector3.one;
		rotate_angle = 0.0f;
	}
}