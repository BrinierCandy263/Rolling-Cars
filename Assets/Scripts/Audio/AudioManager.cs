using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// <summary>
/// Audio Manager // Process
/// and set all audio in game
/// </summary>
public static class AudioManager
{
    //declare fields
    private static bool _initialized = false;
    private static AudioSource _audioSource;

    private static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    /// <summary>
    /// Gets whether or not the audio manager has been initialized
    /// </summary>
    public static bool Initialized
    {
        get { return _initialized; }
    }

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source)
    {
        _initialized = true;
        _audioSource = source;

        Array audioClipsNames = Enum.GetValues(typeof(AudioClipName));

        foreach (AudioClipName audioClipName in audioClipsNames)
        {
            audioClips.Add(audioClipName, Resources.Load<AudioClip>(audioClipName.ToString()));
        }
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name)
    {
        _audioSource.PlayOneShot(audioClips[name]);
    }
}
