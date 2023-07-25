using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    
    private float health;
    private float lerpTime;
    [Header("Health Bar")]
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;
    [Header("Damage Overlay")]
    public Image overlay;
    public float overlayDuration;
    public float overlayFadeSpeed;
    private float durationTimer;
    void Start()
    {
        health = maxHealth;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();

        if (overlay.color.a > 0) {
            durationTimer += Time.deltaTime;
            if (durationTimer > overlayDuration) {
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * overlayFadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }
    }

    public void UpdateHealthUI() {
        float fillf = frontHealthBar.fillAmount;
        float fillb = backHealthBar.fillAmount;
        float healthFrac = health / maxHealth;
        if (fillb > healthFrac) {
            frontHealthBar.fillAmount = healthFrac;
            backHealthBar.color = Color.red;
            lerpTime += Time.deltaTime;
            float percentComplete = lerpTime / chipSpeed;
            percentComplete *= percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillb, healthFrac, percentComplete);
        } else if (fillf < healthFrac) {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = healthFrac;
            lerpTime += Time.deltaTime;
            float percentComplete = lerpTime / chipSpeed;
            percentComplete *= percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillf, healthFrac, percentComplete);
        }
    }

    public void TakeDamage(float damage) {
        health -= damage;
        lerpTime = 0f;

        durationTimer = 0f;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1);
    }
    public void RestoreHealth(float healAmount) {
        health += healAmount;
        lerpTime = 0f;
    }
}
