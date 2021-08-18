using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    //private Animator animator;
    private CharacterUI characterUI;
    private Character character;
    private GameObject characterVisual;


    private void AttackBahaviour_StateEnd()
    {
        character.AttackEnd = true;
    }

    public void SetCharacter(Character character, bool left = false)
    {
        this.character = character;
        character.ClearEvents();

        character.HPChanged += Character_HPChanged;
        character.Died += Character_Died;
        //character.CharacterAttack += Character_CharacterAttack;

        SpawnCharacterVisual(left);
        //if (character.CurrentHP <= 0) AnimateRecover();
    }

    private void SpawnCharacterVisual(bool left)
    {
        if (characterVisual != null)
        {
            //attackBahaviour.StateEnd -= AttackBahaviour_StateEnd;
            Destroy(characterVisual);
        }

        characterVisual = Instantiate(character.CharacterPrefab, transform, false);
        //animator = characterVisual.GetComponentInChildren<Animator>();
        characterUI = characterVisual.GetComponentInChildren<CharacterUI>();

        characterUI.SetupHPBar(character);

        if (left)
        {
            var renderer = characterVisual.GetComponentInChildren<SpriteRenderer>();
            renderer.flipX = true;
        }
    }

    private void Character_HPChanged(int value)
    {
        characterUI.OnHPChanged(value);
        //AnimateHurt();
    }

    /*private void Character_CharacterAttack()
    {
        AnimateAttack();
    }*/

    private void Character_Died()
    {
        character.HPChanged -= Character_HPChanged;
        character.Died -= Character_Died;
        //character.CharacterAttack -= Character_CharacterAttack;
        //AnimateDeath();
    }

    /*[ContextMenu("Recover")]
    private void AnimateRecover()
    {
        animator.SetTrigger("Recover");
    }

    [ContextMenu("Hurt")]
    private void AnimateHurt()
    {
        animator.SetTrigger("Hurt");
        var animation = animator.GetCurrentAnimatorClipInfo(0);
        Debug.LogWarning($"!!!! Hurt time : {animator.GetCurrentAnimatorClipInfo(0)[0].clip.length}");
    }

    [ContextMenu("Died")]
    private void AnimateDeath()
    {
        animator.SetTrigger("Death");
    }

    [ContextMenu("Attack")]
    private void AnimateAttack()
    {
        animator.SetTrigger("Attack");
    }*/
}
