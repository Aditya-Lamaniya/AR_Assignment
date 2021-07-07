using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ReferenceLoader : MonoBehaviour
{
    [SerializeField] List<GameObject> containedAssets = new List<GameObject>();

    public List<GameObject> ContainedAssets
    {
        get { return containedAssets; }
    }
    void Start()
    {
        Addressables.LoadAssetsAsync<GameObject>("Remote_Prefab", OnLoadDone);
    }

    private void OnLoadDone(GameObject obj)
    {
        containedAssets.Add(obj);
    }
    private void OnLoadDone(AsyncOperationHandle<GameObject> obj)
    {
        containedAssets.Add(obj.Result);
    }

    
}
