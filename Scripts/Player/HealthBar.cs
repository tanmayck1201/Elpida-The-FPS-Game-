using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour{
    public Slider slider;
    public float maxHealth = 100f;
    public float current;
    public void setMaxHealth() {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }
    public void setHealth (float health){

        slider.value = health;
        
    }
    public float currenthealth () {
        current = slider.value;
        return current;
    }
    public void damageTaken (float damage){
        currenthealth();
        setHealth (current - damage);
    }
    public void Heal (float healing){
        current = currenthealth();
        if (current < maxHealth - healing){
            setHealth (current + healing);
        }
        else {
            setHealth (maxHealth);
        }
    }
    //setMaxHealth (maxHealth);

}
