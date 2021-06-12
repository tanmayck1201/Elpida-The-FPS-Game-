using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        Invoke("Destroyobj",10f);
    }

    public void Destroyobj (){
        Destroy (gameObject);
    }

}