using UnityEngine;

public class damage : MonoBehaviour
{
    public Animator anim;
    public float health = 100f;
    public bool isDead = false;

    public void Damage1(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Debug.Log("dead");
            anim.SetBool ("dead", true);
            anim.SetBool ("run", false);
            anim.SetBool ("attack", false);
            isDead = true;
            Invoke("Destroyobj",2f);
        }
    }

    public void Destroyobj (){
        //isDead = true;
        Destroy (gameObject);
    }

    // Update is called once per frame
    /*void Update()
    {
        if (health <= 0f)
        {
            //Debug.Log("dead");
            anim.SetBool ("dead", true);
            anim.SetBool ("run", false);
            anim.SetBool ("attack", false);
            Invoke("Destroyobj",5f);
        }
    }*/
}

