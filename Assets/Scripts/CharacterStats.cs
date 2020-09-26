using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int currentLevel;
    public int currentXp;
    public int[] expToLevelUp;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.currentLevel>= this.expToLevelUp.Length) {
            return;
        }

        if(this.currentXp>= this.expToLevelUp[this.currentLevel]) {
            this.currentLevel++;
        }

    }

    public void AddExperience(int exp) {
        this.currentXp += exp;
    }


}
