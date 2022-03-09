using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using TMPro;

public class HealthUI : NetworkBehaviour
{
    [SerializeField] LivingEntity player;
    [SerializeField] Image healthImage;
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
        healthImage.fillAmount = currentHealth / maxHealth;
        healthText.text = currentHealth.ToString() + "<color=#74E87A> | " + maxHealth.ToString();
    }
}
