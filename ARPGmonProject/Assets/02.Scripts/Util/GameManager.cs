using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public SceneChanger Scene { get; private set; }
    public GpsSensor Gps { get; private set; }

    private void Start() 
    {
        Scene = GetComponent<SceneChanger>();
        Gps = GetComponentInChildren<GpsSensor>();
    }


}
