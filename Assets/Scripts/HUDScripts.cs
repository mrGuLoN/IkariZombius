using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class HUDScripts : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI healthText, ammoText, moneyText;
        

    void Start()
    {
        Health._healthHud += HPUpDate;
        GunController._ammoHud += AmmoUpDate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HPUpDate(float hp)
    {
        if (hp > 0)
            healthText.text = hp.ToString();
        else healthText.text = "Nice meat!";
    }

    private void AmmoUpDate(int magazine, int ammo)
    {
        if (ammo <= 0 && magazine <=0) ammoText.text = "Alarm! NEED AMMO!";
        else if (ammo <= 0) ammoText.text = magazine.ToString() + " / NON";
        else ammoText.text = magazine.ToString() + " / " + ammo.ToString();
    }
}
