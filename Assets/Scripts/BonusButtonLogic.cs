using UnityEngine;
using UnityEngine.UI;

public class BonusButtonLogic : MonoBehaviour
{

    public Text healText;
    public Text jetpackText;
    public Text damageText;
    public Text shieldText;

    public void Heal()
    {
        BonusLogic.ConsumeBonus(BonusLogic.BonusType.Heals, 1);
    }

    public void JetPack()
    {
        BonusLogic.ConsumeBonus(BonusLogic.BonusType.Jetpacks, 1);
    }

    public void Damage()
    {
        BonusLogic.ConsumeBonus(BonusLogic.BonusType.DamageUps, 1);
    }

    public void Shield()
    {
        BonusLogic.ConsumeBonus(BonusLogic.BonusType.Shields, 1);
    }

    public void UpdatePowerups()
    {
        healText.text = "Heal Packs: " + DataHolder._healsCount.ToString();
        jetpackText.text = "JetPacks: " + DataHolder._jetpacksCount.ToString();
        damageText.text = "Damage Boosts: " + DataHolder._damageUpsCount.ToString();
        shieldText.text = "Shields: " + DataHolder._shieldsCount.ToString();
    }


    private void Update()
    {
        UpdatePowerups();
    }
}
