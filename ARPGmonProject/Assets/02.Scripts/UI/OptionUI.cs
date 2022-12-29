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


// 보스 몬스터
// 몬스터

// 옵저버 패턴 => Reactive Programming
// GUI Application
// UI System
// ViewController : 캔버스가 들고 있고, 뷰와 프리젠터를 연결하는 역할
// View : 캔버스 첫 번째 자식 오브젝트(Empty)에 추가되며, UGUI 참조하는 역할
// Presenter : 로직 구현
// Model : 관련된 데이터만 가지고 있으며, 추가 기능 X, Mono State이 적용되어 있기 때문에 Model.~


}
