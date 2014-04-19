using UnityEngine;
using System.Collections;

public class ButtonOpenURL : MonoBehaviour {

	public string url = "";
	public string fburl = "";

	void OnClick(){
		if(fburl != ""){
			float startTime = Time.timeSinceLevelLoad;
			Application.OpenURL(fburl); 
			if ( Time.timeSinceLevelLoad - startTime <= 1.0f ) { 
				Application.OpenURL(url);
			}
		}
		else if(url.Contains("http")){
			Application.OpenURL (url);
		}
	}
}
