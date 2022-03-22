using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewBonusUI", menuName = "BonusButtonUI")]
public class BonusButtonUI : ScriptableObject
{
    [SerializeField]
    private Button BonusButton;
    [SerializeField]
    private Text BonusText;
}
