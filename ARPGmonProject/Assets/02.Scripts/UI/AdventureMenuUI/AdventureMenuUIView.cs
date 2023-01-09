using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureMenuUIView : MonoBehaviour
{
    [field: SerializeField] public GameObject[] BackMenu { get; private set; }
    [field: SerializeField] public BackButton BackButton { get; private set; }

    [field: SerializeField] public GameObject InventoryUI { get; private set; }
    [field: SerializeField] public GameObject OptionUI { get; private set;}

    [field: SerializeField] public Button InventoryButton { get; private set; }
    [field: SerializeField] public Button OptionButton { get; private set; }
    [field: SerializeField] public Button ExitButton { get; private set; }
}
