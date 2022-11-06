using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    KeyCode[] Keycodes = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3 };

    private void Start(){
        SelectedWeapon();
    }

    private void Update(){

        int previousSelectedWeapon = selectedWeapon;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f){
            selectedWeapon = (selectedWeapon + 1) % transform.childCount;
        }
        
        if(Input.GetAxis("Mouse ScrollWheel") < 0f){
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            if (Input.GetKeyDown(Keycodes[i]))
            {
                selectedWeapon = i;
            }
        }

        if (previousSelectedWeapon != selectedWeapon){
            SelectedWeapon();
        }
    }

    void SelectedWeapon(){
        int i = 0;
        foreach (Transform weapon in transform){
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

}
