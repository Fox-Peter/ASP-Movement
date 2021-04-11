using NaughtyAttributes;
using UnityEngine;

public class PlayAudioManagerClipAction : ActionBase
{
    public AudioManager audioManager;

    [ReorderableList]
    public string[] clipName;

    public override void Execute()
    {
        if(audioManager != null)
        {
            foreach(string name in clipName)
            {
                audioManager.Play(name);
            }
        }
    }
}
