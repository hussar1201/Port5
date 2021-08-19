using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject camera;
    public Gun gun;
    public ParticleSystem ps;


    public void Fire()
    {
        if (GameManager.instance.flag_gameover || UIManager.instance.flag_menu_opened) return;

        RaycastHit hit;
        Debug.Log("Shooting");
        gun.PlayEffect();
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {

            Debug.Log("IN IF");
            if (hit.collider.gameObject.CompareTag("Aircraft_Enemy"))
            {
                Destroy(hit.transform.gameObject);
                UIManager.instance.UploadScore(10);
                Instantiate(ps, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }
}
