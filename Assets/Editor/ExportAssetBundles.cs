using UnityEngine;
using UnityEditor;
public class ExportAssetBundles {
	[MenuItem("Assets/Build AssetBundle From Selection - Track dependencies - Android with a Shortcut Key %&a")]
	static void ExportResourceAndroid () {
	    // Bring up save panel
		string path = Application.dataPath + "/Resources/AssetBundles/Android/";
	    if (path.Length != 0) {
	        // Build the resource file from the active selection.
	        Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
			foreach(Object obj in selection){
				Object[] thisObj = new Object[1];
				thisObj[0] = obj;
				BuildPipeline.BuildAssetBundle(obj, thisObj, path + obj.name + ".unity3d", BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets,BuildTarget.Android);
			}
			Selection.objects = selection;
	    }
	}

	[MenuItem("Assets/Build AssetBundle From Selection - Track dependencies - iOS with a Shortcut Key %&i")]
	static void ExportResourceIOS () {
	    // Bring up save panel
		string path = Application.dataPath + "/Resources/AssetBundles/iOS/";
		if (path.Length != 0) {
			// Build the resource file from the active selection.
			Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
			foreach(Object obj in selection){
				Object[] thisObj = new Object[1];
				thisObj[0] = obj;
				BuildPipeline.BuildAssetBundle(obj, thisObj, path + obj.name + ".unity3d", BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets,BuildTarget.iPhone);
			}
			Selection.objects = selection;
		}
	}

}