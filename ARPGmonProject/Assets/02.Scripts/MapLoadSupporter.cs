using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoadSupporter : MonoBehaviour
{
    private MeshRenderer[] _mesh;
    [SerializeField] private Material[] _settingMaterial = new Material[2];
    [SerializeField] private Material[] _playMaterial = new Material[2];

    public void MapLoadComplete()
    {
        _mesh = GetComponentsInChildren<MeshRenderer>();

        SetBuildingOption();
    }

    public void SetBuildingOption()
    {
        foreach (MeshRenderer renderer in _mesh)
        {
            if (renderer.gameObject.name[0] == 'E')
            {
                renderer.gameObject.tag = "Building";
            }

            renderer.materials = _settingMaterial;
        }
    }

    public void SetMaterial(Material[] Mat)
    {
        foreach (MeshRenderer renderer in _mesh)
        {
            renderer.materials = Mat;
        }
    }

}
