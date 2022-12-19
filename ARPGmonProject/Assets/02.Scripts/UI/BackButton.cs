using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    private List<GameObject> _backMenu = new List<GameObject>();
    public GameObject ParentUI { get; set; }

    private void OnEnable() 
    {
        BackMenuActSet(false);
    }

    private void OnDisable() 
    {
        BackMenuActSet(true);
    }

    public void BackMenuSet(GameObject[] BackMenu)
    {
        for(int i = 0; i < BackMenu.Length; ++i)
        {
            _backMenu.Add(BackMenu[i]);
        }
    }

    private void BackMenuActSet(bool Active)
    {
        for(int i = 0; i < _backMenu.Count; ++i)
        {
            _backMenu[i].SetActive(Active);
        }
    }

    public void ExitUI()
    {
        ParentUI.SetActive(false);
    }
}
