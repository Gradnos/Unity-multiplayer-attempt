using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class HealthUI : NetworkBehaviour
{
    [SerializeField] LivingEntity player;
    [SerializeField] Image healthImage;


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
    }
}
