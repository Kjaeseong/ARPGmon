using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureMainUI : MonoBehaviour
{
    [field: SerializeField] public MapRotateUI MapRotateUI { get; set; }
    [field: SerializeField] public StatusUI StatusUI { get; set; }
    [field: SerializeField] public AdventureMenuUI MenuUI { get; set; }
    [field: SerializeField] public OptionUI OptionUI { get; set; }
    [field: SerializeField] public InventoryUI InventoryUI { get; set; }
    

    public void RotateComplete()
    {
        StatusUI.gameObject.SetActive(true);
    }

    public void MenuButton()
    {
        MenuUI.gameObject.SetActive(true);
    }


}
