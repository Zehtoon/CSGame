using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    public Color invincibleColor = Color.gray;
    public Color damageColor = Color.red; // Color to change to when damaged
    [SerializeField]
    public float colorDuration = 0.5f; // Total duration of the flashing effect
    [SerializeField]
    public int flashCount = 5; // Number of times to flash

    private Color originalColor;
    private Material characterMaterial;

    void Start()
    {
        characterMaterial = GetComponent<Renderer>().material;
        originalColor = characterMaterial.color;
    }

    public void ApplyDamageEffect()
    {
        StopCoroutine("HandleDamageEffect");
        StartCoroutine("HandleDamageEffect");
    }
    public void ApplyInvincibilityEffect()
    {
        StartCoroutine("InvincibilityEffect");
    }
    IEnumerator HandleDamageEffect()
    {
        for (int i = 0; i < flashCount; i++)
        {
            // Alternate between the damage color and original color
            characterMaterial.color = (characterMaterial.color == originalColor) ? damageColor : originalColor;
            yield return new WaitForSeconds(colorDuration / (flashCount * 2));
        }
        // Ensure the color is reset to original after the effect
        characterMaterial.color = originalColor;
    }   
    IEnumerator InvincibilityEffect()
    {
        characterMaterial.color = invincibleColor;
        yield return new WaitForSeconds(10f);
        characterMaterial.color = originalColor;
    }
}
