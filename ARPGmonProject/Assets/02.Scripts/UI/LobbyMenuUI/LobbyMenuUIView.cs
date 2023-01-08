using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyMenuUIView : MonoBehaviour
{
    [field: SerializeField] public GameObject StatusUI { get; private set; }
    [field: SerializeField] public GameObject OptionUI { get; private set; }
    [field: SerializeField] public GameObject MonsterInfoUI { get; private set; }
    [field: SerializeField] public GameObject InventoryUI { get; private set; }

    [field: SerializeField] public Button InfoButton { get; private set; }
    [field: SerializeField] public Button FeedButton { get; private set; }
    [field: SerializeField] public Button TrainingButton { get; private set; }
    [field: SerializeField] public Button OptionButton { get; private set; }
    [field: SerializeField] public Button InventoryButton { get; private set; }
    [field: SerializeField] public Button AdventurButton { get; private set; }
}
