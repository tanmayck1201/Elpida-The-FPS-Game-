using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class characterMovement : MonoBehaviour
{
    public CharacterController controller;
    public StaminaBar staminabar;
    public HealthBar healthbar;
    
    //public Damage damage;

    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float crouchSpeed = 2f;
    public float characterSpeed = 0f;
    public float gravity = -9.81f;
    public float jumpHeight = 2.5f;
    public float stamina = 100f;
    public float time = 0f;
    public float giveDamage;
    public float currentHealth;
    public float maxHealth;
    

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    public bool isGrounded;
    public bool isRunning;
    public bool isWalking;
    public bool isCrouching;
    public bool isMoving;

    void Start (){
        stamina = 100f;
        staminabar.setStamina (stamina);
    }

    void FixedUpdate (){
        giveDamage = 0f;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0f){
            velocity.y = -2f;   
        }

        float x = Input.GetAxis ("Horizontal");
        float z = Input.GetAxis ("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (move.magnitude > 0){
            isMoving = true;
        }else{
            isMoving = false;
        }

        if (Input.GetKeyDown (KeyCode.LeftShift) && isGrounded ){
            characterSpeed = runSpeed;
            isRunning = true;
        }
        
        if (Input.GetKeyUp (KeyCode.LeftShift)){
            isRunning = false;
            characterSpeed = walkSpeed;
            isWalking = true;
        }

        if (isRunning == true && stamina > 0f && isMoving){
            isWalking = false;
            stamina -= 1f;
            staminabar.setStamina (stamina);
            if (stamina == 0){
                characterSpeed = walkSpeed;
            }
        }
        else if (isRunning == false && stamina < 100f){
            characterSpeed = walkSpeed;
            stamina += 1f;
            staminabar.setStamina (stamina);
        }

        else if (isGrounded && move.magnitude > 0){
            isWalking = true;
            characterSpeed = walkSpeed;
        }
        else {
            isWalking = false;
            if (!isGrounded){
                characterSpeed = 0f;
            }
        }

        if (Input.GetButtonDown ("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt (jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime * 2f;

        controller.Move (velocity * Time.deltaTime);

        if (Input.GetKeyDown (KeyCode.C) && isGrounded){
            isCrouching = true;
            controller.height = 2.5f; 
        }

        if (Input.GetKeyUp (KeyCode.C)){
            controller.height = 3.8f;
            isCrouching = false;
        }
        if (isCrouching){
            characterSpeed = crouchSpeed;
        }
        else if (!isCrouching){
            characterSpeed = walkSpeed;
        }
        controller.Move (move * characterSpeed * Time.deltaTime);
        
        
        //distance = groundCheck.position.y;

        if (velocity.y < -20f){
            giveDamage += 80f * 9.812f / 1000f;
            healthbar.damageTaken (giveDamage);
        }

        if (healthbar.currenthealth() <= 0f){
            SceneManager.LoadScene("Game-Play");
            Debug.Log("Game Reset");
        }
    }

}
