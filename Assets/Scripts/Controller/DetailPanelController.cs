using UnityEngine;
using System.Collections;

public class DetailPanelController : MonoBehaviour {

	public float ScaleSpeed = 1.0f;

	public DetailPanel modelDetailPanel;
	public DetailPanel floorDetailPanel;
	public DetailPanel wallDetailPanel;
	
	private ModelItem modelItem;
	private int markerID = -1;
	private DetailPanel nowDetailPanel;


	public void Init(ModelItem modelItem, int markerID){
		this.markerID = markerID;
		if(this.modelItem != modelItem){
			this.modelItem = modelItem;
			InitData();
		}
		nowDetailPanel.panelObj.SetActive (true);
	}

	void InitData(){
		if(modelItem.category.Contains("F")){
			nowDetailPanel = floorDetailPanel;
			wallDetailPanel.panelObj.SetActive(false);
			modelDetailPanel.panelObj.SetActive(false);
		}
		else if(modelItem.category.Contains("W")){
			nowDetailPanel = wallDetailPanel;
			floorDetailPanel.panelObj.SetActive(false);
			modelDetailPanel.panelObj.SetActive(false);
		}
		else{
			nowDetailPanel = modelDetailPanel;
			wallDetailPanel.panelObj.SetActive(false);
			floorDetailPanel.panelObj.SetActive(false);
		}
		nowDetailPanel.bgSprite.spriteName = nowDetailPanel.bgSprite.spriteName.Substring (0, nowDetailPanel.bgSprite.spriteName.Length - 1) + markerID.ToString();
		nowDetailPanel.moreButton.GetComponent<UISprite> ().spriteName = "moreButton" + markerID.ToString();
		nowDetailPanel.moreButton.GetComponent<UIButton> ().normalSprite = "moreButton" + markerID.ToString ();
		nowDetailPanel.moreButton.GetComponent<UIButton> ().pressedSprite = "moreButton" + markerID.ToString () + "OnPress";

		if(nowDetailPanel.nameLabel != null){
			nowDetailPanel.nameLabel.text = modelItem.name;
		}
		if(nowDetailPanel.scaleSlider != null){
			nowDetailPanel.scaleSlider.value = modelItem.scaling_factor.x * 0.5f;
		}
		if(nowDetailPanel.rotateSlider != null){
			nowDetailPanel.rotateSlider.value = (modelItem.rotate_angle+180.0f)/360.0f;
		}
		if(nowDetailPanel.scaleUpHeightButton != null){
			nowDetailPanel.scaleUpHeightButton.AddComponent<UIEventListener>().onPress = OnScaleButtonPress;
		}
		if(nowDetailPanel.scaleDownHeightButton != null){
			nowDetailPanel.scaleDownHeightButton.AddComponent<UIEventListener>().onPress = OnScaleButtonPress;
		}
		if(nowDetailPanel.scaleUpWidthButton != null){
			nowDetailPanel.scaleUpWidthButton.AddComponent<UIEventListener>().onPress = OnScaleButtonPress;
		}
		if(nowDetailPanel.scaleDownWidthButton != null){
			nowDetailPanel.scaleDownWidthButton.AddComponent<UIEventListener>().onPress = OnScaleButtonPress;
		}
		if(nowDetailPanel.scaleUpLengthButton != null){
			nowDetailPanel.scaleUpLengthButton.AddComponent<UIEventListener>().onPress = OnScaleButtonPress;
		}
		if(nowDetailPanel.scaleDownLengthButton != null){
			nowDetailPanel.scaleDownLengthButton.AddComponent<UIEventListener>().onPress = OnScaleButtonPress;
		}
		UpdateSizeLabelText ();
	}

	void UpdateSizeLabelText(){
		if(nowDetailPanel.heightLabel != null){
			nowDetailPanel.heightLabel.text = "H  [0F8593]" + (modelItem.height*modelItem.scaling_factor.y).ToString("F0") + "[-]  cm";
		}
		if(nowDetailPanel.lengthLabel != null){
			nowDetailPanel.lengthLabel.text = "L  [0F8593]" + (modelItem.length*modelItem.scaling_factor.x).ToString("F0") + "[-]  cm";
		}
		if(nowDetailPanel.widthLabel != null){
			nowDetailPanel.widthLabel.text = "W  [0F8593]" + (modelItem.width*modelItem.scaling_factor.z).ToString("F0") + "[-]  cm";
		}
	}

	public void OnScaleSliderValueChange(){
		if(modelItem != null){
			modelItem.scaling_factor =  Vector3.one * Mathf.Max(0.01f, nowDetailPanel.scaleSlider.value) * 2.0f;
			UpdateSizeLabelText ();
		}
	}

	public void OnScaleSingleSliderValueChange(){
		if(modelItem != null){

		}
	}

	public void OnRotateSliderValueChange(){
		if(modelItem != null){
			modelItem.rotate_angle = nowDetailPanel.rotateSlider.value * 360.0f - 180.0f;
			UpdateSizeLabelText ();
		}
	}

	public void OnScaleButtonPress(GameObject go, bool state){
		if(state){
			int factor = 1;
			Vector3 v = Vector3.zero;
			if(go.name.Contains("Down")){
				factor = -1;
			}
			if(go.name.Contains("Len")){
				v = new Vector3(0.1f,0.0f,0.0f);
			}
			if(go.name.Contains("Hei")){
				v = new Vector3(0.0f,0.1f,0.0f);
			}
			if(go.name.Contains("Wid")){
				v = new Vector3(0.0f,0.0f,0.1f);
			}
			modelItem.scaling_factor += v*ScaleSpeed*factor;
			UpdateSizeLabelText ();
		}
	}
}



[System.Serializable]
public class DetailPanel{
	public GameObject panelObj;
	public UILabel nameLabel;
	public UILabel lengthLabel;
	public UILabel heightLabel;
	public UILabel widthLabel;
	public UISprite bgSprite;
	public UISlider scaleSlider;
	public UISlider scaleSingleSlider;
	public UISlider rotateSlider;
	public GameObject moreButton;
	public GameObject scaleUpLengthButton;
	public GameObject scaleDownLengthButton;
	public GameObject scaleUpWidthButton;
	public GameObject scaleDownWidthButton;
	public GameObject scaleUpHeightButton;
	public GameObject scaleDownHeightButton;
}