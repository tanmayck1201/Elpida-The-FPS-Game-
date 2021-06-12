using System.Collections;
using System.Resources;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Camera Camera;
    public ParticleSystem pistolFlash;
    public ParticleSystem rifleFlash;
    public ParticleSystem hitEffect;
    public WeapoSwitcher weapontype;

    public Text PistolAmmoDisplay;
    public Text RifleAmmoDisplay;
    public Text AmmoCount;

    public float Range = 100f;
    public float fireRate = 15f;
    private float nextTimetoFire = 0f;

    //public float damagehere = 50f;

    // Ammo Part
    [Header("Ammo Management")]
    public int pistolCapacity = 6;
    public int rifleCapacity = 20;
    public int pistolAmmoCount = 6;
    public int rifleAmmoCount = 20;
    public float reloadTime = 3f;
    public bool isReloading = false;
    public int availableAmmo = 50;
    public int maxavailableAmmo = 50;
    public bool isFiring = false;
    public bool isFull = true;


    void surfaceHit (Vector3 _pos, Vector3 _normal) {

        DoHit(_pos, _normal);
    }

    void DoHit (Vector3 _pos, Vector3 _normal) {
        ParticleSystem _hitEffect = (ParticleSystem)Instantiate(hitEffect, _pos, Quaternion.LookRotation(_normal));
        Destroy(_hitEffect, 2f);
    }
    
    void Start() {
        PistolAmmoDisplay.text = "x" + pistolAmmoCount;
        RifleAmmoDisplay.text = "x" + rifleAmmoCount;
        AmmoCount.text = "x" + availableAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        AmmoCount.text = "x" + availableAmmo;
         
        if(pistolAmmoCount == 0 || rifleAmmoCount == 0 || Input.GetKeyDown(KeyCode.R))
        {
            if (weapontype.SelectedWeapon == 0)
            {
                isReloading = true;
                StartCoroutine(Reload());
                return;
            }
            if (weapontype.SelectedWeapon == 1)
            {
                isReloading = true;
                StartCoroutine(Reload());
                return;
            }

        }
        //if(isReloading = true && ammoCount == maxAmmo) {
          //  isReloading = false;
        //}

        
        if (Input.GetButton("Fire1") && Time.time >= nextTimetoFire )
        {
            //isFiring = true;
            if (rifleAmmoCount > 0 && pistolAmmoCount > 0)
            {
                if (weapontype.SelectedWeapon == 0)
                {
                    pistolAmmoCount -= 1;
                    pistolFlash.Play();
                }
                if (weapontype.SelectedWeapon == 1)
                {
                    rifleAmmoCount -= 1;
                    rifleFlash.Play();
                }
                PistolAmmoDisplay.text = "x" + pistolAmmoCount;
                RifleAmmoDisplay.text = "x" + rifleAmmoCount;
                nextTimetoFire = Time.time + 1f / fireRate;
                weapon();
                //muzzleFlash.Stop();
            }          
            
        }
        else if (Input.GetButton("Fire2"))
        {
            //isFiring = true;
            if (rifleAmmoCount > 0 && pistolAmmoCount > 0 && Input.GetKeyDown(KeyCode.F) && Time.time >= nextTimetoFire)
            {
                if (weapontype.SelectedWeapon == 0)
                {
                    pistolAmmoCount -= 1;
                    pistolFlash.Play();
                }
                if (weapontype.SelectedWeapon == 1)
                {
                    rifleAmmoCount -= 1;
                    rifleFlash.Play();
                }
                nextTimetoFire = Time.time + 1f / fireRate;
                weapon();
                PistolAmmoDisplay.text = "x" + pistolAmmoCount;
                RifleAmmoDisplay.text = "x" + rifleAmmoCount;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && isFiring == false){
            meleeAttack();
        }
        if (Input.GetButtonUp("Fire1") || Input.GetButtonUp("Fire2")){
            isFiring = false;
        }
    }


     IEnumerator Reload()
     {
         isFiring = false;
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        while (availableAmmo > 0 && ( pistolAmmoCount <= pistolCapacity || rifleAmmoCount <= rifleCapacity))
        {
            //ammoCount  += 1;
            if (weapontype.SelectedWeapon == 0 && pistolAmmoCount < pistolCapacity){
                pistolAmmoCount += 1;
                availableAmmo -= 1;
                if (pistolAmmoCount == pistolCapacity){
                    isFull = true;
                }
            }
            if (weapontype.SelectedWeapon == 1 && rifleAmmoCount < rifleCapacity){
                rifleAmmoCount += 1;
                availableAmmo -= 1;
                if (rifleAmmoCount == rifleCapacity){
                    isFull = true;
                }
            }
           // if (pistolAmmoCount == pistolCapacity && rifleAmmoCount == rifleCapacity)
            PistolAmmoDisplay.text = "x" + pistolAmmoCount;
            RifleAmmoDisplay.text = "x" + rifleAmmoCount;
            AmmoCount.text = "x" + availableAmmo;
            if (isFull == true){
                break;
            }
        }
        isReloading = false;  
     }

    void weapon()
    {
        isFiring = true;
        isFull = false;
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit))
        {
            if (hit.transform.tag == "Enemy")
            {
                damage enemy = hit.transform.GetComponent<damage>();
                enemy.Damage1(20f);
                Debug.Log("Bullet Hit");
                
            }
            surfaceHit(hit.point, hit.normal);          
        }
    }
    void meleeAttack () {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit))
        {
            if (hit.transform.tag == "Enemy" && hit.distance <= 5f)
            {
                damage enemy = hit.transform.GetComponent<damage>();
                enemy.Damage1(100f);
                Debug.Log("Melee");
            }          
        }
    }
}
