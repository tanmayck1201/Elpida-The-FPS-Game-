using UnityEngine;

public class wepoman : MonoBehaviour
{

    public Animator anim;

    public characterMovement character;

    public Shooting shoot;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (x == 0 && z == 0)
        {
            anim.SetBool("Breathe", true);
            anim.SetBool("Walk", false);
            anim.SetBool("Fire", false);
            anim.SetBool("Run", false);
            anim.SetBool("Reload", false);
            anim.SetBool("Melee", false);
            anim.SetBool("FireLoop", false);
            anim.SetBool("ZoomIn", false);
            anim.SetBool("ZoomFire", false);
            anim.SetBool("ZoomfireLoop", false);
            anim.SetBool("ZoomWalk", false);

            if (Input.GetButton("Fire2"))
            {
                anim.SetBool("Fire", false);
                anim.SetBool("Breathe", false);
                anim.SetBool("Walk", false);
                anim.SetBool("Run", false);
                anim.SetBool("Reload", false);
                anim.SetBool("Melee", false);
                anim.SetBool("FireLoop", false);
                anim.SetBool("ZoomIn", true);
                anim.SetBool("ZoomFire", false);
                anim.SetBool("ZoomfireLoop", false);
                anim.SetBool("ZoomWalk", false);

                if (Input.GetKey(KeyCode.F))
                {
                    anim.SetBool("ZoomFire", true);
                    anim.SetBool("Fire", false);
                    anim.SetBool("Breathe", false);
                    anim.SetBool("Walk", false);
                    anim.SetBool("Run", false);
                    anim.SetBool("Reload", false);
                    anim.SetBool("Melee", false);
                    anim.SetBool("FireLoop", false);
                    anim.SetBool("ZoomIn", false);
                    anim.SetBool("ZoomfireLoop", false);
                    anim.SetBool("ZoomWalk", false);
                }
                /*else if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyUp(KeyCode.F))
                {
                    anim.SetBool("ZoomFire", true);
                    anim.SetBool("Fire", false);
                    anim.SetBool("Breathe", false);
                    anim.SetBool("Walk", false);
                    anim.SetBool("Run", false);
                    anim.SetBool("Reload", false);
                    anim.SetBool("Melee", false);
                    anim.SetBool("FireLoop", false);
                    anim.SetBool("ZoomIn", false);
                    anim.SetBool("ZoomfireLoop", false);
                }*/
            }
        }
        else
        {
            if (character.isWalking == true)
            {
                anim.SetBool("Breathe", false);
                anim.SetBool("Walk", true);
                anim.SetBool("Fire", false);
                anim.SetBool("Run", false);
                anim.SetBool("Reload", false);
                anim.SetBool("Melee", false);
                anim.SetBool("FireLoop", false);
                anim.SetBool("ZoomIn", false);
                anim.SetBool("ZoomFire", false);
                anim.SetBool("ZoomfireLoop", false);
                anim.SetBool("ZoomWalk", false);

                if (Input.GetButton("Fire2"))
                {
                    anim.SetBool("Fire", false);
                    anim.SetBool("Breathe", false);
                    anim.SetBool("Walk", false);
                    anim.SetBool("Run", false);
                    anim.SetBool("Reload", false);
                    anim.SetBool("Melee", false);
                    anim.SetBool("FireLoop", false);
                    anim.SetBool("ZoomIn", true);
                    anim.SetBool("ZoomFire", false);
                    anim.SetBool("ZoomfireLoop", false);
                    anim.SetBool("ZoomWalk", false);

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        anim.SetBool("ZoomFire", true);
                        anim.SetBool("Fire", false);
                        anim.SetBool("Breathe", false);
                        anim.SetBool("Walk", false);
                        anim.SetBool("Run", false);
                        anim.SetBool("Reload", false);
                        anim.SetBool("Melee", false);
                        anim.SetBool("FireLoop", false);
                        anim.SetBool("ZoomIn", false);
                        anim.SetBool("ZoomfireLoop", false);
                        anim.SetBool("ZoomWalk", false);
                    }
                }
            }
            /*if (character.isWalking == false){
                anim.SetBool("Breathe", false);
                anim.SetBool("Walk", false);
                anim.SetBool("Fire", false);
                anim.SetBool("Run", true);
                anim.SetBool("Reload", false);
            }*/
            if (character.isRunning == true && character.isGrounded)  
            {
                anim.SetBool("Run", true);
                anim.SetBool("Breathe", false);
                anim.SetBool("Walk", false);
                anim.SetBool("Fire", false);
                anim.SetBool("Reload", false);
                anim.SetBool("Melee", false);
                anim.SetBool("FireLoop", false);
                anim.SetBool("ZoomIn", false);
                anim.SetBool("ZoomFire", false);
                anim.SetBool("ZoomfireLoop", false);
                anim.SetBool("ZoomWalk", false);

                if (Input.GetButtonDown("Fire2"))
                {
                    anim.SetBool("Fire", false);
                    anim.SetBool("Breathe", false);
                    anim.SetBool("Walk", false);
                    anim.SetBool("Run", false);
                    anim.SetBool("Reload", false);
                    anim.SetBool("Melee", false);
                    anim.SetBool("FireLoop", false);
                    anim.SetBool("ZoomIn", true);
                    anim.SetBool("ZoomFire", false);
                    anim.SetBool("ZoomfireLoop", false);
                    anim.SetBool("ZoomWalk", false);
                
                    if (Input.GetButton("Fire1") && Input.GetButtonDown("Fire2"))
                    {
                        anim.SetBool("ZoomFire", true);
                        anim.SetBool("Fire", false);
                        anim.SetBool("Breathe", false);
                        anim.SetBool("Walk", false);
                        anim.SetBool("Run", false);
                        anim.SetBool("Reload", false);
                        anim.SetBool("Melee", false);
                        anim.SetBool("FireLoop", false);
                        //anim.SetBool("ZoomIn", false);
                        anim.SetBool("ZoomfireLoop", false);
                        anim.SetBool("ZoomWalk", false);
                    }
                }
            }
            /*if (character.isRunning == false){
                anim.SetBool("Run", false);
                anim.SetBool("Breathe", false);
                anim.SetBool("Walk", false);
                anim.SetBool("Fire", false);
                anim.SetBool("Reload", false);

            }*/
        }
        if (Input.GetButton("Fire1"))
        {
            anim.SetBool("Fire", false);
            anim.SetBool("Breathe", false);
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
            anim.SetBool("Reload", false);
            anim.SetBool("Melee", false);
            anim.SetBool("FireLoop", true);
            anim.SetBool("ZoomIn", false);
            anim.SetBool("ZoomFire", false);
            anim.SetBool("ZoomfireLoop", false);
            anim.SetBool("ZoomWalk", false);
            if (Input.GetButton ("Fire2")){
                anim.SetBool("zoomfire", true);
            }
        }
        if (shoot.isReloading == true)
        {
            anim.SetBool("Fire", false);
            anim.SetBool("Breathe", false);
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
            anim.SetBool("Reload", true);
            anim.SetBool("Melee", false);
            anim.SetBool("FireLoop", false);
            anim.SetBool("ZoomIn", false);
            anim.SetBool("ZoomFire", false);
            anim.SetBool("ZoomfireLoop", false);
            anim.SetBool("ZoomWalk", false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && shoot.isFiring == false)
        {
            anim.SetBool("Melee", true);
            anim.SetBool("Fire", false);
            anim.SetBool("Breathe", false);
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
            anim.SetBool("Reload", false);
            anim.SetBool("FireLoop", false);
            anim.SetBool("ZoomIn", false);
            anim.SetBool("ZoomFire", false);
            anim.SetBool("ZoomfireLoop", false);
            anim.SetBool("ZoomWalk", false);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Fire", true);
            anim.SetBool("Breathe", false);
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
            anim.SetBool("Reload", false);
            anim.SetBool("Melee", false);
            anim.SetBool("FireLoop", false);
            anim.SetBool("ZoomIn", false);
            anim.SetBool("ZoomFire", false);
            anim.SetBool("ZoomfireLoop", false);
            anim.SetBool("ZoomWalk", false);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("Fire", true);
            anim.SetBool("Breathe", false);
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
            anim.SetBool("Reload", false);
            anim.SetBool("Melee", false);
            anim.SetBool("FireLoop", false);
            anim.SetBool("ZoomIn", false);
            anim.SetBool("ZoomFire", false);
            anim.SetBool("ZoomfireLoop", false);
            anim.SetBool("ZoomWalk", false);
        }
        
    }
}
