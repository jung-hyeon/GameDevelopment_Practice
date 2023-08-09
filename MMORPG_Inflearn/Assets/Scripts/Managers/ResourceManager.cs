using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = this.Load<GameObject>($"Prefabs/{path}");
        if (prefab == null)
        {
            Debug.Log($"Filed to road prefab : {path}");
            return null;
        }
        return Object.Instantiate(prefab, parent);  // Object�� ���̴� ����: this.Instantiate�� ���ȣ�� ���� ���ؼ� �������
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        Object.Destroy(go);
    }
}
