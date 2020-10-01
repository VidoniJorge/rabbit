using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIPlayerOptionController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool uiVisible = false;
    private bool isChange = true;

    public GameObject panelXp;
    public GameObject panelInventory;

    public Text xpPoint;
    public Text livePoint;
    public Text powerPoint;
    public Text defencePoint;
    public Text manaPoint;

    private CharacterStats characterStats;

    void Start()
    {
        this.characterStats = this.GetComponentInParent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isChange && Input.GetAxis(Const.INPUT_CHECK_POINT) > 0.5)
        {
            this.uiVisible = !this.uiVisible;
            this.isChange = false;
            panelXp.SetActive(this.uiVisible);
        }

        if (Input.GetAxis(Const.INPUT_CHECK_POINT) < 0.5)
        {
            this.isChange = true;
        }

        refresh();
    }

    private void refresh()
    {
        this.xpPoint.text = "Puntos por cambiar: " + this.characterStats.xpPoint;
        this.livePoint.text = "Vida: " + this.characterStats.currentLifePoint;
        this.powerPoint.text = "Poder: " + this.characterStats.currentPowerPoint;
        this.defencePoint.text = "Defensar: " + this.characterStats.currentDefensePoint;
        this.manaPoint.text = "Mana: " + this.characterStats.currentManaPoint;
    }

    public void OnClickUpPoint(string name)
    {
        this.characterStats.SumPoint(name, 1);
    }

    public void OnClickDownPoint(string name)
    {
        this.characterStats.SumPoint(name, -1);
    }
}
