using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject camera;
    public Gun gun;
    public ParticleSystem ps;

    private float time_for_interval = .3f;
    private float timer = 0f;
    private bool flag_btn_down = false;

    private void Update()
    {
        if (GameManager.instance.flag_gameover || UIManager.instance.flag_menu_opened) return;

        timer += Time.deltaTime;

        if (timer >= time_for_interval && flag_btn_down)
        {
            timer = 0f;
            RaycastHit hit;
            Debug.Log("Shooting");
            gun.PlayEffect();
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
            {                           
                if (hit.collider.gameObject.CompareTag("Aircraft_Enemy"))
                {
                    Destroy(hit.transform.gameObject);
                    UIManager.instance.UploadScore(10);
                    Instantiate(ps, hit.point, Quaternion.LookRotation(hit.normal));
                }
            }
        }
    }

    public void OnFireBtnDown()
    {
        if (GameManager.instance.flag_gameover || UIManager.instance.flag_menu_opened) return;     
        flag_btn_down = true;
    }

    public void OnFireBtnUp()
    {
        if (GameManager.instance.flag_gameover || UIManager.instance.flag_menu_opened) return;       
        flag_btn_down = false;
    }
}
