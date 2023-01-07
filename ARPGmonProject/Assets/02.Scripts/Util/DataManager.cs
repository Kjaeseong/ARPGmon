using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // -----------------------------육성 몬스터의 정보를 저장히기 위한 변수
    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField] public int Level    { get; set; }
    [field: SerializeField] public float HP       { get; set; }
    [field: SerializeField] public float EP       { get; set; }
    [field: SerializeField] public int ATK      { get; set; }
    [field: SerializeField] public int DFE      { get; set; }
    [field: SerializeField] public float EXE    { get; set; }
    // -----------------------------------------------------------------

    [field: SerializeField] public float MaxHP { get; set; }
    [field: SerializeField] public float MaxEP { get; set; }
    [field: SerializeField] public float MaxEXE { get; set; }
}
