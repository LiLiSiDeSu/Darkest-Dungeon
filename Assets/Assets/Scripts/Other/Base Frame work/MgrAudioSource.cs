using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MgrAudioSource : InstanceBaseAuto_Mono<MgrAudioSource>
{
    private float BkVolume;
    private float SoundVolume;

    private AudioSource BkMusic = null;    
    private GameObject ObjSound = null;
    private List<AudioSource> ListSound = new();   

    private void Update()
    {        
        for (int i = ListSound.Count - 1; i >= 0; i--)
        {
            if (!ListSound[i].isPlaying)
            {
                Destroy(ListSound[i]);
                ListSound.Remove(ListSound[i]);
            }
        }
    }

    public void ChangeBkVolume(float volume)
    {
        BkVolume = volume;

        if (BkMusic != null)
            BkMusic.volume = BkVolume;
    }

    public void ChangeSoundVolume(float volume)
    {
        SoundVolume = volume;
        for (int i = 0; i < ListSound.Count; i++)
        {
            ListSound[i].volume = SoundVolume;
        }
    }

    public void PlayBkMusic(string name)
    {
        if (BkMusic == null)
        {
            GameObject obj = new GameObject("BkMusic");
            BkMusic = obj.AddComponent<AudioSource>();
        }

        MgrRes.GetInstance().LoadAsync<AudioClip>("Music/ImgBk/" + name, (clip) =>
        {
            BkMusic.loop = true;
            BkMusic.clip = clip;
            BkMusic.volume = BkVolume;
            BkMusic.Play();
        });
    }

    public void PauseBkMusic()
    {
        if (BkMusic == null)
            return;
        BkMusic.Stop();
    }

    public void PlaySound(string name, bool isLoop, UnityAction<AudioSource> callback = null)
    {
        if (ObjSound == null)
            ObjSound = new GameObject("Sound_Root");

        MgrRes.GetInstance().LoadAsync<AudioClip>("Music/Sound/" + name, (clip) =>
        {
            AudioSource audiosource = ObjSound.AddComponent<AudioSource>();
            audiosource.loop = isLoop;
            audiosource.volume = SoundVolume;
            audiosource.clip = clip;
            audiosource.Play();
            ListSound.Add(audiosource);
            if (callback != null)
                callback(audiosource);
        });        
    }

    public void PauseSound(AudioSource audioSource)
    {
        if (ListSound.Contains(audioSource))
        {
            audioSource.Stop();
            GameObject.Destroy(audioSource);
            ListSound.Remove(audioSource);
        }
    }
}
