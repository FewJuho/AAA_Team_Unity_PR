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

    public GameObject jetpackCanvas;
    public BonusTimer jetpackTimer;

    public GameObject damageCanvas;
    public BonusTimer damageTimer;

    public GameObject shieldCanvas;
    public BonusTimer shieldTimer;

    public AudioClip jetpackPickupAudio;
    public AudioClip healPickupAudio;
    public AudioClip adrenalinePickupAudio;
    public AudioClip shieldPickupAudio;
    public AudioClip missingAudio;

    public void Heal()
    {
        GetComponent<AudioSource>().PlayOneShot(missingAudio);

        if (DataHolder._healsCount > 0 && DataHolder.maxHP != DataHolder.currentHP)
        {
            healpack.SetActive(true);
            BonusLogic.ConsumeBonus(BonusLogic.BonusType.Heals, 1);
            healAnim.SetTrigger("HealTrigger");
            GetComponent<AudioSource>().PlayOneShot(healPickupAudio);
        }
    }

    public void JetPack()
    {
        if (DataHolder._jetpacksCount > 0)
        {
            jetpack.SetActive(true);
            jetpackAnim.SetTrigger("JetpackTrigger");
            jetpackCanvas.SetActive(true);
            jetpackTimer.StartTimer();
            GetComponent<AudioSource>().PlayOneShot(jetpackPickupAudio);

            if (DataHolder.jatpackActivated)
            {
                jetpackTimer.ResetTimer();
            }

            BonusLogic.ConsumeBonus(BonusLogic.BonusType.Jetpacks, 1);

        }
    }

    public void Damage()
    {
        if (DataHolder._damageUpsCount > 0)
        {
            GetComponent<AudioSource>().PlayOneShot(adrenalinePickupAudio);

            damagepack.SetActive(true);
            damageAnim.SetTrigger("DamageTrigger");
            damageCanvas.SetActive(true);
            damageTimer.StartTimer();
            if (DataHolder.damageMultiplier == 2.0f)
            {
                damageTimer.ResetTimer();
            }

            BonusLogic.ConsumeBonus(BonusLogic.BonusType.DamageUps, 1);

        }
    }

    public void Shield()
    {
        if (DataHolder._shieldsCount > 0)
        {
            GetComponent<AudioSource>().PlayOneShot(shieldPickupAudio);

            shieldpack.SetActive(true);
            shieldAnim.SetTrigger("ShieldTrigger");
            shieldCanvas.SetActive(true);
            shieldTimer.StartTimer();
            if (DataHolder.shieldActivated)
            {
                shieldTimer.ResetTimer();
            }

            BonusLogic.ConsumeBonus(BonusLogic.BonusType.Shields, 1);

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
            jetpackCanvas.SetActive(false);
        }

        if (!DataHolder.shieldActivated)
        {
            shieldpack.SetActive(false);
            shieldCanvas.SetActive(false);
        }

        if (DataHolder.damageMultiplier == 1.0f)
        {
            damagepack.SetActive(false);
            damageCanvas.SetActive(false);
        }

    }

   
    private void Update()
    {
        UpdatePowerups();
    }
}
