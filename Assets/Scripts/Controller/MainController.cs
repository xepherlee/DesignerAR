using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;

public class MainController : MonoBehaviour {

	static public DesignerAR designerAR;
	static public string modelURL;

	public UICenterOnChild tutorialCenterOnChild;
	public ModelsController modelsController;
	public ARUIController arUIController;

	private string jsonURL;
	private string cacheURL;
	private UIAtlas modelIconAtlas;

	void Awake(){
		jsonURL = "https://designerar.firebaseio.com/designerar_new.json";
		cacheURL = "file:///" + Application.persistentDataPath;
		tutorialCenterOnChild.onFinished = OnTutorialPageChanged;
		StartCoroutine (GetJsonDataFromInternet ());
	}

	IEnumerator GetJsonDataFromInternet(){
		WWW www = new WWW (jsonURL);
		yield return www;
		if (www.error == null) {
			designerAR = JsonMapper.ToObject<DesignerAR>(www.text);
			modelURL = designerAR.link;
			byte[] bytes=www.bytes;
			Directory.CreateDirectory(Application.persistentDataPath +"/Json/");
			File.WriteAllBytes(Application.persistentDataPath +"/Json/ar.json", bytes);
			Debug.Log("GetJsonDataFromInternetSuccess");
		}
		else{
			Debug.Log(www.error);
			StartCoroutine(GetJsonDataFromCache());
		}
	}

	IEnumerator GetJsonDataFromCache(){
		WWW www = new WWW(cacheURL+"/Json/ar.json");
		yield return www;
		if (www.error == null) {
			designerAR = JsonMapper.ToObject<DesignerAR>(www.text);
			modelURL = designerAR.link;
			Debug.Log("GetJsonDataFromCacheSuccess");
		}
		else{
			Debug.Log(www.error);
			GetJsonDataFromResource();
		}
	}

	void GetJsonDataFromResource(){
		designerAR = JsonMapper.ToObject<DesignerAR>((Resources.Load("ar",typeof(TextAsset)) as TextAsset).text);
		modelURL = designerAR.link;
		Debug.Log("GetJsonDataFromResource");
	}

	IEnumerator GetAtlasFromInternet(){
		WWW www = new WWW (modelURL + "ModelIconAtlas.unity3d");
		yield return www;
		if (www.error == null) {
			AssetBundleRequest request = www.assetBundle.LoadAsync("ModelIconAtlas",typeof(GameObject));
			yield return request;
			modelIconAtlas = (request.asset as GameObject).GetComponent<UIAtlas>();

		}
		else{

		}
	}

	void OnTutorialPageChanged(){
		Debug.Log (tutorialCenterOnChild.centeredObject.name);
		if(tutorialCenterOnChild.centeredObject.name != "pend"){

		}
		else{
			tutorialCenterOnChild.transform.parent.parent.gameObject.SetActive(false);
			modelsController.gameObject.SetActive(true);
			arUIController.gameObject.SetActive(true);
		}
	}
}
