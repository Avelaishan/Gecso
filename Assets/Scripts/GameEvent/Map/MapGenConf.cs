using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapGenConf : MonoBehaviour
{
    [SerializeField] private Slider rowSlider;
    [SerializeField] private Slider columnSlider;
    [SerializeField] private Text rowTextField;
    [SerializeField] private Text columnTextField;

    private void Start()
    {
        rowSlider.onValueChanged.AddListener((v) =>
        {
            rowTextField.text = v.ToString("0");
            MapData.Row = v;

        });
        columnSlider.onValueChanged.AddListener((v) =>
        {
            columnTextField.text = v.ToString("0");
            MapData.Column = v;
            if (MapData.Column == 0)
            {
                MapData.Column = 2;
            }
        });
    }
}
