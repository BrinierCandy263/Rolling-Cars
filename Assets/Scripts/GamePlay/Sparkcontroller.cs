using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SparkController : MonoBehaviour
{
    private ObjectPool _sparkPool;

    private void Awake()
    {
        GameObject poolObject = GameObject.FindGameObjectWithTag("SparkPool");
        if (poolObject != null) _sparkPool = poolObject.GetComponent<ObjectPool>();
        if (_sparkPool == null) Debug.LogError("No ObjectPool found with the 'SparkPool' tag.");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                GameObject spark = _sparkPool.GetObject(contact.point, Quaternion.identity);
                ParticleSystem particleSystem = spark.GetComponent<ParticleSystem>();
                particleSystem.Play();
                StartCoroutine(ReturnToPoolAfterDelay(spark, 1f));
            }
    }

    private IEnumerator ReturnToPoolAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        _sparkPool.ReturnObject(obj);
    }
}
