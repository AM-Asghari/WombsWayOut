using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HaakEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Image ui;
    public bool hit;
    public AudioSource death, loopSound;
    private float timer;
    private void Update()
    {
        if (hit)
        {
            loopSound.Pause();
            ui.gameObject.SetActive(true);
            ui.color = new UnityEngine.Color(ui.color.r, ui.color.g, ui.color.b, ui.color.a + Time.deltaTime);
            timer += Time.deltaTime;
        }
        if (hit && timer >=5)
        {
            SceneManager.LoadScene(0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            hit = true;
            death.Play();
        }
    }
}
