using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : MonoBehaviour
{
    private const string tag_player = "Player";
    public int damage = 10;
    public DamageNumber damageNumber;
   
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(tag_player))
        {
            collision.gameObject.GetComponent<HealthManager>()
                .DamageCharacter(damage);
            DamageNumber clone = (DamageNumber)Instantiate(this.damageNumber, collision.transform.position, Quaternion.Euler(Vector3.zero));
            clone.damagePoints = damage;
            clone.damageText.color = Color.white;
        }
    }
}
