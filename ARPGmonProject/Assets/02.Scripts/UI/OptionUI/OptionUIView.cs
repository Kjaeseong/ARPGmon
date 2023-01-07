using UnityEngine;
using UnityEngine.UI;

public class OptionUIView : MonoBehaviour
{
    [field: SerializeField] public Slider Bgm { get; set; }
    [field: SerializeField] public Slider Se { get; set; }
    [field: SerializeField] public BackButton BackButton { get; set; }
    [field: SerializeField] public GameObject[] BackMenu { get; set; }
}
