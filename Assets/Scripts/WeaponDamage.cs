using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public int damageBase;

    public GameObject hurtAnimation;
    public GameObject hitPoint;
    public GameObject damageNumber;

    private CharacterStats playerStat;
    const int damageMin = 1;

    private void Start()
    {
        this.playerStat = GetComponentInParent<CharacterStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(Const.TAG_ENEMY)) {
            // se le tiene que agregar defensa a los enemigos
            int damage = calculateDamege(0);
            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
            Instantiate(this.hurtAnimation, this.hitPoint.transform.position, this.hitPoint.transform.rotation);
            var clone = (GameObject)Instantiate(this.damageNumber, this.hitPoint.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damagePoints = damage;
        }
    }

    private int calculateDamege(int defense)
    {
        float avgIncrementePower = (float)(playerStat.currentPowerPoint / 50.0);
        double powerDamageFinal = this.damageBase + (this.damageBase * avgIncrementePower);
        int damage = (int)(powerDamageFinal - defense);
        if (damage > 0)
        {
            return damage;
        }
        return damageMin;
    }
}
