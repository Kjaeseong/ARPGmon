using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    //-------------------------------- 각 매니저들에 접근하기 위한 변수 
    public SceneChanger Scene { get; private set; }
    public GpsSensor Gps { get; private set; }
    public DataManager Data { get; private set; }
    public AudioManager Audio { get; private set; }
    //--------------------------------------------------------------

    public GameObject PlayerMon { get; set; }
    public GameObject Player { get; set; }
    public GameObject TargetMon { get; set; }
    
    [field: SerializeField] public float CoroutineCycle { get; private set; }
    public WaitForSeconds Cycle { get; private set; }



    private void Start() 
    {
        Cycle = new WaitForSeconds(CoroutineCycle);

        Scene = GetComponent<SceneChanger>();
        Gps = GetComponentInChildren<GpsSensor>();
        Data = GetComponent<DataManager>();
        Audio = GetComponentInChildren<AudioManager>();
    }


}
