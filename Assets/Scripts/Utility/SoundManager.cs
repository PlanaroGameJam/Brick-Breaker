using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum eAudioStyle
    {
        BGM,
        SFX,
    }

    [Serializable]
    public struct AudioInfo
    {
        public string name;
        public AudioClip clip;
        public eAudioStyle audioStyle;
    }

    [Serializable]
    public struct AudioPlayer
    {
        public AudioSource audioSource;
        public float volume;
    }

    [SerializeField]
    private List<AudioInfo> m_audioList;
    [SerializeField]
    private AudioPlayer m_bgmPlayer;
    [SerializeField]
    private AudioPlayer m_sfxPlayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public AudioInfo GetBGM(string findName)
    {
        return m_audioList.Find(audio => audio.name == findName && audio.audioStyle == eAudioStyle.BGM);
    }

    public AudioInfo GetSFX(string findName)
    {
        return m_audioList.Find(audio => audio.name == findName && audio.audioStyle == eAudioStyle.SFX);
    }

    public void PlayBGM(in string findName)
    {
        m_bgmPlayer.audioSource.PlayOneShot(GetBGM(findName).clip, m_bgmPlayer.volume);
    }

    public void PlaySFX(in string findName)
    {
        m_sfxPlayer.audioSource.PlayOneShot(GetSFX(findName).clip, m_sfxPlayer.volume);
    }

}
