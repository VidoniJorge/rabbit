using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    // Start is called before the first frame update

    public bool flashActive;
    public float flashLengh;
    private float flachCounter;

    public int expWhenDefeated;

    private float avg66;
    private float avg33;

    private SpriteRenderer characterRenderer;
    void Start()
    {
        this.currentHealth = this.maxHealth;
        this.characterRenderer = this.GetComponent<SpriteRenderer>();
        this.avg66 = this.flashLengh * 0.66f;
        this.avg33 = this.flashLengh * 0.33f;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.currentHealth <= 0)
        {
            this.gameObject.SetActive(false);
            if (this.gameObject.tag.Equals(Const.TAG_ENEMY)) {
                GameObject.Find("Player").GetComponent<CharacterStats>().AddExperience(this.expWhenDefeated);
            }
        }

        if(this.flashActive)
        {
            this.flachCounter -= Time.deltaTime;

            if (this.flachCounter <= 0)
            {
                this.flashActive = false;
                this.ToggleColor(true);
            } 
            else if (this.flachCounter < this.avg33 || this.flachCounter > this.avg66)
            {
                this.ToggleColor(false);
            } 
            else
            {
                this.ToggleColor(true);
            }


        }
    }

    public void DamageCharacter(int damage)
    {
        this.currentHealth -= damage;
        if(this.flashLengh > 0)
        {
            this.flashActive = true;
            this.flachCounter = this.flashLengh;
        }
    }
    public void UpdateMaxHealth(int newMaxHelth)
    {
        this.maxHealth = newMaxHelth;
        this.currentHealth = this.maxHealth;
    }

    private void ToggleColor(bool visible)
    {
        this.characterRenderer.color = new Color(   this.characterRenderer.color.r,
                                                    this.characterRenderer.color.g,
                                                    this.characterRenderer.color.b,
                                                    (visible?1.0f:0.0f));
    }
}
