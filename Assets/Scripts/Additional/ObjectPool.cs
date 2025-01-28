using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int poolSize = 10;
    private List<GameObject> pool;

    void Awake()
    {
        // Initialize the pool
        pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false); // Disable the object initially
            pool.Add(obj);
        }
    }

    // Get an inactive object from the pool
    public GameObject GetObject(Vector2 position, Quaternion rotation)
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.SetActive(true);
                return obj;
            }
        }

        // If no inactive objects are available, optionally expand the pool
        GameObject newObj = Instantiate(prefab, position, rotation);
        newObj.SetActive(true);
        pool.Add(newObj);
        return newObj;
    }

    // Return an object to the pool
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
