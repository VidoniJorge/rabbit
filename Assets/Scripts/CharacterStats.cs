using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script para controlar los stats del objeto
 */ 
public class CharacterStats : MonoBehaviour
{
    public int currentLevel;
    public int currentXp;
    public int[] expToLevelUp;
    public int xpPoint = 0; //puntos de experiencia a repartir

    public int currentManaPoint;
    public int currentDefensePoint;
    public int currentLifePoint;
    public int currentPowerPoint;

    void Update()
    {
        if(this.validatedIfMaxLevel()) {
            return;
        }

        if(this.validatedLevelUp()) {
            this.currentLevel++;
            this.xpPoint++;
        }

    }

    /**
     * funcion que valida si el personaje llego a nivel maximo
     */ 
    private bool validatedIfMaxLevel() { 
        return this.currentLevel >= this.expToLevelUp.Length;
    }

    /**
     * funcion que valida si tenemos la experiencia necesaria para subir de nivel
     */
    private bool validatedLevelUp() {
        return this.currentXp >= this.expToLevelUp[this.currentLevel];
    }

    public void AddExperience(int exp) {
        this.currentXp += exp;
    }

    public void change()
    {
        Debug.Log("que cosa linda");
    }
        
    public void SumPoint(string name, int mult) {
        if (this.xpPoint > 0)
        {
            switch (name)
            {
                case Const.POINT_NAME_DEFENSE:
                    this.SumDefensePoint(1 * mult);
                    break;
                case Const.POINT_NAME_MANA:
                    this.SumManaPoint(1 * mult);
                    break;
                case Const.POINT_NAME_LIFE:
                    this.SumLifePoint(1 * mult);
                    break;
                case Const.POINT_NAME_POWER:
                    this.SumPowerPoint(1 * mult);
                    break;
            }
            this.xpPoint -= mult;
        }
    }

    private void SumPowerPoint(int point)
    {
        this.currentPowerPoint += point;
    }

    private void SumLifePoint(int point)
    {
        this.currentLifePoint += point;
    }
    private void SumManaPoint(int point)
    {
        this.currentManaPoint += point;
    }
    private void SumDefensePoint(int point)
    {
        this.currentDefensePoint += point;
    }
}
