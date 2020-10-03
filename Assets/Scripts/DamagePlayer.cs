using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : MonoBehaviour
{
    public int damageBase = 100;
    public DamageNumber damageNumber;

    const int damageMin = 1;
    public float porcentajeDamege = 1;

    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(Const.TAG_PLAYER))
        {
            CharacterStats playerStat = collision.gameObject.GetComponent<CharacterStats>();
            int damage = calculateDamage(playerStat.currentDefensePoint);
            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
            

            DamageNumber clone = (DamageNumber)Instantiate(this.damageNumber, collision.transform.position, Quaternion.Euler(Vector3.zero));
            clone.damagePoints = damage;
            clone.damageText.color = Color.white;
        }
    }

    private int calculateDamage(int defense)
    {   
        float resultado = this.damageBase * porcentajeDamege - defense  ;
        if(resultado > 0)
        {
            return (int)resultado;
        }
        return damageMin;
    }
}
