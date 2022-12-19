using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _bgm;
    [SerializeField] private AudioSource _se;

    public float _bgmVolume { get { return _bgm.volume; } }
    public float _seVolume { get { return _se.volume; } }

    public void VolumeSet(float bgm, float se)
    {
        _bgm.volume = bgm;
        _se.volume = se;
    }

    private void BgmPlay(AudioClip Clip)
    {
        _bgm.Stop();
        _bgm.clip = Clip;
        _bgm.Play();
    }

    private void SePlay(AudioClip Clip)
    {
        _se.Stop();
        _se.clip = Clip;
        _bgm.Play();
    }


}
