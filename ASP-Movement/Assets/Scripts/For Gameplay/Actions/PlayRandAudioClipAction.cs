using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandAudioClipAction : ActionBase
{
    public AudioSource AudioSource;

    [ReorderableList]
    public AudioClip[] Clips;

    public override void Execute()
    {
        AudioSource.clip = Clips[Random.Range(0, Clips.Length)];
        AudioSource.Play();
    }
}
