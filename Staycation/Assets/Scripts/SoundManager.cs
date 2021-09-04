using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //////////////////////
    //SINGLETON STUFF
    protected SoundManager() { }
    private static SoundManager _instance = null;
    public static SoundManager Instance
    {
        get { return SoundManager._instance; }
    }
    private void Awake()
    {
        if (_instance != this && _instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }
    //
    /////////////////////

    public AudioSource sfxSource;
    public AudioSource[] voiceSources;
    public AudioClip itemSnap;
    public AudioClip negative;
    public AudioClip newText;
    public AudioClip screenToBlack;
    public AudioClip wakeUp;
    
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayVoice(int ID, float duration)
    {
        voiceSources[ID].Play();
        voiceSources[ID].time = Random.Range(0, voiceSources[ID].clip.length);
    }

    IEnumerator HaltVoiceLater(float duration)
    {
        yield return new WaitForSeconds(duration);
        HaltVoice();
    }

    public void HaltVoice()
    {
        foreach (AudioSource voice in voiceSources)
            voice.Stop();

        StopCoroutine("HaltVoice");
    }
}
