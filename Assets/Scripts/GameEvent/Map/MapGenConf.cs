using UnityEngine;
using UnityEngine.UI;

public class MapGenConf : MonoBehaviour
{
    [SerializeField] Slider rowSlider;
    [SerializeField] Slider columnSlider;
    [SerializeField] Text rowTextField;
    [SerializeField] Text columnTextField;

    private void Start()
    {
        rowSlider.onValueChanged.AddListener((v) =>
        {
            rowTextField.text = v.ToString("0");
            MapGenData.Row = (int)v;

        });
        columnSlider.onValueChanged.AddListener((v) =>
        {
            columnTextField.text = v.ToString("0");
            MapGenData.Column = (int)v;

        });
    }
}
