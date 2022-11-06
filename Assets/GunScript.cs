using UnityEngine;
using UnityEngine.Audio;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 1f;
    public float fireRate = 15f;

    public Camera fpsCam;
    //public ParticleSystem muzzleFlash;

    float nextTimeToFire = 0f;

    public AudioSource audioSource;
    public AudioClip audioClipArray;

    // Update is called once per frame
    void Update(){

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire){
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    AudioClip RandomClip(){
        return audioClipArray;
    }

    void Shoot(){

        //muzzleFlash.Play();      
        audioSource.PlayOneShot(RandomClip());
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);

            EnemyScript target = hit.transform.GetComponent<EnemyScript>();

            if(target != null){
                target.TakeDamage(damage);
            }
        }       
    }
       
       
}
