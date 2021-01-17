using UnityEngine.Audio;
using UnityEngine;

//[System.Serializable]
public class Fire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public AudioSource shell;
    public Shooting shoot;

    // Start is called before the first frame update
    void Start()
    {
        shell = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shoot.isFiring == true)
        {
            shell.Play();
            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.transform.position = transform.position + transform.forward;
            bulletObject.transform.forward = transform.forward;
            
        }

    }
}
