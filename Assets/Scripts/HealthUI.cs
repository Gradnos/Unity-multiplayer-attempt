using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using TMPro;
using DG.Tweening;

public class HealthUI : NetworkBehaviour
{
    [SerializeField] LivingEntity player;
    [SerializeField] Image healthImage;
    [SerializeField] Image underHealth;
    [SerializeField] TextMeshProUGUI healthText;


    void Update()
    {
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("LocalPlayer");
            if(playerObject != null)
            {
                player = playerObject.GetComponent<LivingEntity>();
                if (player != null)
                {
                player.OnHealthChanged += ChangeHealthBar;
                }
            }
        }
    }

    void ChangeHealthBar(float currentHealth, float maxHealth, float damage)
    {
        healthImage.fillAmount = currentHealth/maxHealth;
        healthText.text = currentHealth.ToString() + "<color=#82ED8D> | " + maxHealth.ToString();
        underHealth.DOFillAmount(currentHealth/maxHealth, 4f).SetEase(Ease.OutExpo);
    }
}
