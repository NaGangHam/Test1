using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class BundleManager : MonoBehaviour{
    string bundleDir = "Bundle";
    string bundleName = "modelsbundle";

    // Start is called before the first frame update
    IEnumerator Start(){
        if (!Directory.Exists(bundleDir)) {
            Directory.CreateDirectory(bundleDir);

            string[] downList = { bundleName, bundleName + ".manifest", "Bundle", "Bundle.manifest" };

            foreach (string down in downList) {
                StartCoroutine(BundleDownload(down));
            }

            StartCoroutine(SetBundle(1f));
        }
        else {
            AssetBundle asset = AssetBundle.LoadFromFile("Bundle/modelsbundle");

            if(asset == null ) {
                yield break;
            }
            var ch42 = asset.LoadAsset<GameObject>("Ch42");
            var p1 = Instantiate(ch42);
            p1.transform.position = new Vector3(-2f, 0f, 0f);

            var ch46 = asset.LoadAsset<GameObject>("Ch46");
            var p2 = Instantiate(ch46);
            p2.transform.position = new Vector3(2f, 0f, 0f);
        }
    }

    IEnumerator BundleDownload(string assetBundle) {
        string url = "https://holosoft.co.kr/test/unity/Bundle/" + assetBundle;

        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if(request.result != UnityWebRequest.Result.Success ) {
            Debug.Log("Error : " + request.error);
        }
        else {
            File.WriteAllBytes(bundleDir + "/" + assetBundle, request.downloadHandler.data);
        }
    }

    IEnumerator SetBundle(float delay) {
        yield return new WaitForSeconds(delay);

        AssetBundle asset = AssetBundle.LoadFromFile("Bundle/modelsbundle");

        if (asset == null) {
            yield break;
        }
        var ch42 = asset.LoadAsset<GameObject>("Ch42");
        var p1 = Instantiate(ch42);
        p1.transform.position = new Vector3(-2f, 0f, 0f);

        var ch46 = asset.LoadAsset<GameObject>("Ch46");
        var p2 = Instantiate(ch46);
        p2.transform.position = new Vector3(2f, 0f, 0f);
    }
}
