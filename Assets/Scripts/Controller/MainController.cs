using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;

public class MainController : DesinerARBehaviour {


	void Start(){
		DesignerARStateManager.SetListenerState (DesignerARStateManager.State.DataInit);
	}

	public override void DataInit ()
	{
		base.DataInit ();
		StartCoroutine (GetJsonDataFromInternet ());
	}

	IEnumerator GetJsonDataFromInternet(){
		string jsonURL = "https://designerar.firebaseio.com/designerar_new.json";
		WWW www = new WWW (jsonURL);
		yield return www;
		if (www.error == null) {
			GlobalObject.SetDesignerAR(JsonMapper.ToObject<DesignerAR>(www.text));
			byte[] bytes=www.bytes;
			Directory.CreateDirectory(Application.persistentDataPath +"/Json/");
			File.WriteAllBytes(Application.persistentDataPath +"/Json/ar.json", bytes);
			Debug.Log("GetJsonDataFromInternetSuccess");
			GetJsonDataComplete();
		}
		else{
			Debug.Log(www.error);
			StartCoroutine(GetJsonDataFromCache());
		}
	}

	IEnumerator GetJsonDataFromCache(){
		WWW www = new WWW("file:///" + Application.persistentDataPath+"/Json/ar.json");
		yield return www;
		if (www.error == null) {
			GlobalObject.SetDesignerAR(JsonMapper.ToObject<DesignerAR>(www.text));
			Debug.Log("GetJsonDataFromCacheSuccess");
			GetJsonDataComplete();
		}
		else{
			Debug.Log(www.error);
			GetJsonDataFromResource();
		}
	}

	void GetJsonDataFromResource(){
		GlobalObject.SetDesignerAR(JsonMapper.ToObject<DesignerAR>((Resources.Load("ar",typeof(TextAsset)) as TextAsset).text));
		Debug.Log("GetJsonDataFromResource");
		GetJsonDataComplete ();
	}


	void GetJsonDataComplete(){
		DesignerARStateManager.SetListenerState (DesignerARStateManager.State.Title);
	}
}
