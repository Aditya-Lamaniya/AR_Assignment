using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.AddressableAssets;

public class AssetSpawner : MonoBehaviour
{
    public ARRaycastManager arRaycastManager;
    public ReferenceLoader loader;

    private List<ARRaycastHit> arRaycastHits = new List<ARRaycastHit>();
    private string btn_name = "NULL";

    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                if (Input.touchCount == 1)
                {
                    //Rraycast Planes
                    if (arRaycastManager.Raycast(touch.position, arRaycastHits))
                    {
                        var pose = arRaycastHits[0].pose;
                        CreateCube(pose.position);
                        return;
                    }

                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        if (hit.collider.tag == "SpawnableObject")
                        {
                            DeleteCube(hit.collider.gameObject);
                        }
                    }
                }
            }
        }
    }

    private void CreateCube(Vector3 position)
    {
        if (btn_name == "NULL")
        {
            return;
        }
        else if (btn_name == "Button_1")
        {
            Debug.Log("Clicked Button1");
            Instantiate(loader.ContainedAssets[0], position, Quaternion.identity);
        }
        else if (btn_name == "Button_2")
        {
            Instantiate(loader.ContainedAssets[1], position, Quaternion.identity);
        }
        else if (btn_name == "Button_3")
        {
            Instantiate(loader.ContainedAssets[2], position, Quaternion.identity);
        }
    }

    private void DeleteCube(UnityEngine.GameObject Object)
    {
        Destroy(Object);
    }

    public void GetButtonName(Button btn)
    {
        btn_name = btn.name;
    }

    //public void ClearAll()
    //{
    //    GameObject[] objectlist = GameObject.FindGameObjectsWithTag("SpawnableObject");
    //    foreach (GameObject obj in objectlist)
    //    {
    //        GameObject.Destroy(obj);
    //    }
    //    Addressables.Release(loader.ContainedAssets[0]);
    //    Addressables.Release(loader.ContainedAssets[1]);
    //    Addressables.Release(loader.ContainedAssets[2]);
    //}
}
