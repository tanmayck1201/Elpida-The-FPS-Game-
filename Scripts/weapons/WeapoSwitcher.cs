using UnityEngine;

public class WeapoSwitcher : MonoBehaviour
{
    public int SelectedWeapon = 0;
    GameObject pistol;
    GameObject rifle;



    // Start is called before the first frame update
    void Start()
    {
        pistol = GameObject.FindGameObjectWithTag("PistolIcon");
        rifle = GameObject.FindGameObjectWithTag("RifleIcon");
        SelectWeapon();
        pistol.SetActive(false);
        rifle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = SelectedWeapon;
        /*if (Input.GetAxis("Mouse ScrollWheel") >= 0f)
        {
            if (SelectedWeapon >= transform.childCount - 1)
            {
                SelectedWeapon = 0;
            }
            else
            {
                SelectedWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (SelectedWeapon <= 0)
            {
                SelectedWeapon = transform.childCount - 1;
            }
            else
            {
                SelectedWeapon--;
            }
        }*/
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 1)
        {
            SelectedWeapon = 1;
        }
        if (previousSelectedWeapon == SelectedWeapon)
        {
            SelectWeapon();
        }

        if (SelectedWeapon == 0){
            pistol.SetActive(true);
            rifle.SetActive(false);
        }
        if (SelectedWeapon == 1){
            rifle.SetActive(true);
            pistol.SetActive(false);
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == SelectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}


