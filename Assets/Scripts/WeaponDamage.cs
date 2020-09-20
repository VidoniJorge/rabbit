using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    private const string tag_enemy = "Enemy";
    public int damage;

    public GameObject hurtAnimation;
    public GameObject hitPoint;
    public GameObject damageNumber;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(tag_enemy)){
            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
            Instantiate(this.hurtAnimation, this.hitPoint.transform.position, this.hitPoint.transform.rotation);
            var clone = (GameObject)Instantiate(this.damageNumber, this.hitPoint.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damagePoints = damage;
        }
    }
}
