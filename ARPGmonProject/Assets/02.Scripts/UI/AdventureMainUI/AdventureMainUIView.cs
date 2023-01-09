using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureMainUIView : MonoBehaviour
{
    [field: SerializeField] public Button MenuButton { get; private set; }
    [field: SerializeField] public GameObject AdventureMenuUI { get; private set; }
}
