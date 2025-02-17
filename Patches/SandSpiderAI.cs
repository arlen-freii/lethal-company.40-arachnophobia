using HarmonyLib;
using UnityEngine;

namespace _40Arachnophobia.Patches;

[HarmonyPatch(typeof(SandSpiderAI))]
public class SandSpiderAI_Patches {

    [HarmonyPatch("Start")]
    [HarmonyPostfix]
    private static void Start_Postfix(SandSpiderAI __instance) {

        GameObject meshContainer = __instance.transform.GetChild(0).gameObject;
        GameObject meshRenderer = meshContainer.transform.GetChild(0).gameObject;
        SkinnedMeshRenderer spiderMesh = meshRenderer.GetComponent<SkinnedMeshRenderer>();
        spiderMesh.enabled = false;

        GameObject animContainer = meshContainer.transform.GetChild(1).gameObject;
        GameObject armature = animContainer.transform.GetChild(0).gameObject;
        GameObject abdomen = armature.transform.GetChild(0).gameObject;

        if (_40Arachnophobia.Instance.SpiderTextPrefab == null) {
            return;
        }

        GameObject spiderText = Object.Instantiate(
            _40Arachnophobia.Instance.SpiderTextPrefab
        );

        spiderText.name = "NewSpiderText";
        
        spiderText.transform.SetParent(abdomen.transform);

        spiderText.transform.localScale = new Vector3(1.86f, 1.86f, 1.86f);
        spiderText.transform.localRotation = new Quaternion(-0.70711f, 0.00008f, 0.00008f, -0.70711f);
        spiderText.transform.localPosition = new Vector3(0.1000419f, -0.8036421f, -0.1765117f);

        spiderText.GetComponent<MeshRenderer>().enabled = true;
        
    }

}
