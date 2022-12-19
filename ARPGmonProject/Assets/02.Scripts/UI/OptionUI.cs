using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    [SerializeField] private Slider _bgm;
    [SerializeField] private Slider _se;
    [SerializeField] private BackButton _backButton;
    [SerializeField][Tooltip("옵션 활성화시 비활성화,\n 옵션 비활성화시 활성화되는 오브젝트")] private GameObject[] _backMenu;

    private void Awake() 
    {
        _backButton.ParentUI = gameObject;
        _backButton.BackMenuSet(_backMenu);
    }

    private void OnEnable() 
    {
        SlideSet();
    }

    private void FixedUpdate() 
    {
        GameManager.Instance.Audio.VolumeSet(_bgm.value, _se.value);
    }

    private void SlideSet()
    {
        _bgm.value = GameManager.Instance.Audio._bgmVolume;
        _se.value = GameManager.Instance.Audio._seVolume;
    }



}
