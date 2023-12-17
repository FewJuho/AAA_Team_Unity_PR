using UnityEngine;
using UnityEngine.UI;

public class BonusButtonLogic : MonoBehaviour
{

    public Text healText;
    public Text jetpackText;
    public Text damageText;
    public Text shieldText;
    public Animator healAnim;
    public Animator jetpackAnim;
    public Animator damageAnim;
    public Animator shieldAnim;

    public GameObject healpack;
    public GameObject jetpack;
    public GameObject damagepack;
    public GameObject shieldpack;
    public void Heal()
    {
        if (DataHolder._healsCount > 0 && DataHolder.maxHP != DataHolder.currentHP)
        {
            healpack.SetActive(true);
            BonusLogic.ConsumeBonus(BonusLogic.BonusType.Heals, 1);
            healAnim.SetTrigger("HealTrigger");
        }
    }

    public void JetPack()
    {
        if (DataHolder._jetpacksCount > 0)
        {
            jetpack.SetActive(true);
            BonusLogic.ConsumeBonus(BonusLogic.BonusType.Jetpacks, 1);
            jetpackAnim.SetTrigger("JetpackTrigger");
        }
    }

    public void Damage()
    {
        if (DataHolder._damageUpsCount > 0)
        {
            damagepack.SetActive(true);
            BonusLogic.ConsumeBonus(BonusLogic.BonusType.DamageUps, 1);
            damageAnim.SetTrigger("DamageTrigger");
        }
    }

    public void Shield()
    {
        if (DataHolder._shieldsCount > 0)
        {
            shieldpack.SetActive(true);
            BonusLogic.ConsumeBonus(BonusLogic.BonusType.Shields, 1);
            shieldAnim.SetTrigger("ShieldTrigger");
        }
    }

    public void UpdatePowerups()
    {
        healText.text = "Heal Packs: " + DataHolder._healsCount.ToString();
        jetpackText.text = "JetPacks: " + DataHolder._jetpacksCount.ToString();
        damageText.text = "Adrenalines: " + DataHolder._damageUpsCount.ToString();
        shieldText.text = "Shields: " + DataHolder._shieldsCount.ToString();

        if (!DataHolder.jatpackActivated)
        {
            jetpack.SetActive(false);
        }
    }

   
    private void Update()
    {
        UpdatePowerups();
    }
}
