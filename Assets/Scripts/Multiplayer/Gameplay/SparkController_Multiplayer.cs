using UnityEngine;
using System.Collections;
using Mirror;

public class SparkController_Multiplayer : NetworkBehaviour
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
        if (isServer) 
        {
            // If not the server, send collision info to the server
            CmdReportCollision(collision.contacts[0].point);
        }
        else 
        {
            // If on the server, directly spawn sparks
            RpcSpawnSpark(collision.contacts[0].point);
        }
    }

    [Command]
    private void CmdReportCollision(Vector2 position)
    {
        // The server now tells all clients to spawn the spark
        RpcSpawnSpark(position);
    }

    [ClientRpc]
    private void RpcSpawnSpark(Vector2 position)
    {
        GameObject spark = _sparkPool.GetObject(position, Quaternion.identity);
        ParticleSystem particleSystem = spark.GetComponent<ParticleSystem>();
        particleSystem.Play();
        StartCoroutine(ReturnToPoolAfterDelay(spark, 1f));
    }

    private IEnumerator ReturnToPoolAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        _sparkPool.ReturnObject(obj);
    }
}
