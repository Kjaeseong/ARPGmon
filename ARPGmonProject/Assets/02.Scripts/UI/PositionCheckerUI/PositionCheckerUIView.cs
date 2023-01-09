using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PositionCheckerUIView : MonoBehaviour
{
    [field: SerializeField] public EventTrigger RightButton { get; private set; }
    [field: SerializeField] public EventTrigger LeftButton { get; private set; }
    [field: SerializeField] public Button OKButton { get; private set; }
    [field: SerializeField] public PositionChecker Checker { get; private set; }
    [field: SerializeField] public GameObject[] NextMenu { get; private set; }
}
