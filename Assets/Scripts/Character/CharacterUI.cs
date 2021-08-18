using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI hpImpact;
    [SerializeField]
    private Image hpBar;
    [SerializeField]
    private TextMeshProUGUI hpMeter;
    [SerializeField]
    private Animator animator;

    private Character character;

    public void OnHPChanged(int value)
    {
        AnimateHPChanged(value);
        UpdateHPBar();
    }

    public void AnimateHPChanged(int value)
    {
        var textValue = "-" + value.ToString();

        hpImpact.text = textValue;
        animator.SetTrigger("HpChange");
    }

    public void SetupHPBar(Character character)
    {
        this.character = character;
        UpdateHPBar();
    }

    private void UpdateHPBar()
    {
        var value = Mathf.Clamp01(character.CurrentHP / (float)character.MaxHP);
        hpBar.fillAmount = value;
        hpMeter.text = $"{character.CurrentHP}/{character.MaxHP}";
    }
}
