using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // -----------------------------육성 몬스터의 정보를 저장히기 위한 변수
    [field: SerializeField] public int Level    { get; set; }
    [field: SerializeField] public int HP       { get; set; }
    [field: SerializeField] public int EP       { get; set; }
    [field: SerializeField] public int ATK      { get; set; }
    [field: SerializeField] public int DFE      { get; set; }
    [field: SerializeField] public float EXE    { get; set; }
    // -----------------------------------------------------------------


}