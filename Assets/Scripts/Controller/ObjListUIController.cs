using UnityEngine;
using System.Collections;

public class ObjListUIController : DesinerARBehaviour {

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
		SetAllChildActive (true);
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
}
