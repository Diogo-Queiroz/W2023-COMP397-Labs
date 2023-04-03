using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioSettingsType
{
    SFX, Ambience, VO
}

[CreateAssetMenu(fileName = "AudioSettings", menuName = "Create Audio/AudioSettings")]
public class AudioSettings : ScriptableObject
{
    public float volume;
    public AudioClip[] audios;
    public string audioType; // SFX or Ambience or Voice Over
    public AudioSettingsType type;

    public AudioClip GetAudioClip(string clipName)
    {
        foreach (AudioClip audioClip in audios)
        {
            if (audioClip.name == clipName)
            {
                return audioClip;
            }
        }

        return null;
    }
}
