using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class HUDScripts : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI healthText, ammoText, moneyText;
    [SerializeField] private UnityEngine.UI.Image damageImg;

    private Color _defmat;   
    private bool _damageImgOn;
    private Animator _ani;

    void Start()
    {
        _ani = GetComponent<Animator>();
        Health._healthHud += HPUpDate;
        GunController._ammoHud += AmmoUpDate;       
        _defmat = damageImg.color;
        _defmat.a = 0f;
        damageImg.color = _defmat;      
    }

    // Update is called once per frame
    void Update()
    {
        if (_damageImgOn == true)
        {
            DamageOff();
        }
    }

    private void HPUpDate(float hp)
    {
        if (hp > 0)
        {
            healthText.text = hp.ToString();
            DamageOn();
        }        
        else healthText.text = "Nice meat!";

        if (hp <30)
        {
            _ani.SetBool("LowHP", true);
        }
        else
        {
            _ani.SetBool("LowHP", false);
        }
    }

    private void AmmoUpDate(int magazine, int ammo)
    {
        if (ammo <= 0 && magazine <=0) ammoText.text = "Alarm! NEED AMMO!";
        else if (ammo <= 0) ammoText.text = magazine.ToString() + " / NON";
        else ammoText.text = magazine.ToString() + " / " + ammo.ToString();
    }

    private void DamageOn()
    {
        _defmat.a += 0.4f;
        damageImg.color = _defmat;
        Debug.Log(damageImg.color.a);
        _damageImgOn = true;
    }

    private void DamageOff()
    {
        _defmat.a -= 0.2f * Time.deltaTime;
        damageImg.color = _defmat;
        if (_defmat.a <=0)
        {
            _damageImgOn = false;
        }
    }

}
