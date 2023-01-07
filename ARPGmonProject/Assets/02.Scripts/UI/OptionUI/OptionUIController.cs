using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionUIController : MonoBehaviour
{
    private OptionUIView _view;

    private void Awake() 
    {
        _view = GetComponent<OptionUIView>();
        _view.BackButton.ParentUI = _view.gameObject;
        _view.BackButton.BackMenuSet(_view.BackMenu);
    }

    private void OnEnable() 
    {
        SlideSet();
    }

    private void FixedUpdate() 
    {
        GameManager.Instance.Audio.VolumeSet(_view.Bgm.value, _view.Se.value);
    }

    private void SlideSet()
    {
        _view.Bgm.value = GameManager.Instance.Audio._bgmVolume;
        _view.Se.value = GameManager.Instance.Audio._seVolume;
    }
}
