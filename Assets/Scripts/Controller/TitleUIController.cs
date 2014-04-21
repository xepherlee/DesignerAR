using UnityEngine;
using System.Collections;

public class TitleUIController : DesinerARBehaviour {

	public override void AR ()
	{
		base.AR ();
		SetAllChildActive (false);
	}

	public override void DataInit ()
	{
		base.DataInit ();
		SetAllChildActive (false);
		this.transform.FindChild ("Mask").gameObject.SetActive (true);
		this.transform.FindChild ("TitlePic").gameObject.SetActive (true);
	}

	public override void ModelSelect ()
	{
		base.ModelSelect ();
		SetAllChildActive (false);
	}

	public override void Title ()
	{
		base.Title ();
		SetAllChildActive (true);
	}

	public override void Tutorial ()
	{
		base.Tutorial ();
		SetAllChildActive (false);
	}

}
