using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class UIManager : MonoBehaviour
{
    public Slider playerHealthBar;
    public Text playerHealthText;
    public Text playerXpText;
    public Text playerLvlText;

    public HealthManager playerHealthManager;
    public CharacterStats characterStats;

    void Update()
    {
        //Actualizo el tamaño de la barra de vida del personaje de acuerdo a su estado maximo actual
        this.playerHealthBar.maxValue = this.playerHealthManager.maxHealth;
        this.playerHealthBar.value = this.playerHealthManager.currentHealth;

        StringBuilder sb = new StringBuilder("HP: ");
        sb.Append(this.playerHealthManager.currentHealth);
        sb.Append("/");
        sb.Append(this.playerHealthManager.maxHealth);
        this.playerHealthText.text = sb.ToString();

        this.playerLvlText.text = "LvL: " + this.characterStats.currentLevel;
        this.playerXpText.text = "Xp: " + this.characterStats.currentXp;
        
    }
}
