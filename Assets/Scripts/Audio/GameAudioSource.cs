using UnityEngine;

/// <summary>
/// Game Audio Source // An audio source
/// for the entire game
/// </summary>
public sealed class GameAudioSource : MonoBehaviour
{
    void Awake()
    {
        // Make sure we only have one of this game object in the game
        if (!AudioManager.Initialized)
        {
            //Initialize audio manager and persist audio source across scenes
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            AudioManager.Initialize(audioSource);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Duplicate game object, so destroy
            Destroy(gameObject);
        }
    }
}
