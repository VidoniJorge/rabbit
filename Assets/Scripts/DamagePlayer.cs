using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : MonoBehaviour
{
    public int damageBase = 10;
    public DamageNumber damageNumber;
   
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(Const.TAG_PLAYER))
        {
            int damage = calculateDamage();
            collision.gameObject.GetComponent<HealthManager>()
                .DamageCharacter(damage);
            DamageNumber clone = (DamageNumber)Instantiate(this.damageNumber, collision.transform.position, Quaternion.Euler(Vector3.zero));
            clone.damagePoints = damage;
            clone.damageText.color = Color.white;
        }
    }

    private int calculateDamage()
    {
        return damageBase;
    }
}
