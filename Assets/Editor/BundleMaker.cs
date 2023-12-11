using System.IO;
using UnityEditor;


public class BundleMaker {
    [MenuItem("Assets/Asset Bundle Build")]
    public static void ShowBundleMaker() {
        string dir = "./Bundle";
        
        if(!Directory.Exists(dir)) {
            Directory.CreateDirectory(dir);
        }

        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);

        EditorUtility.DisplayDialog("AssetBundle built!!", "에셋 번들이 빌드되었습니다.", "확인");
    }

}