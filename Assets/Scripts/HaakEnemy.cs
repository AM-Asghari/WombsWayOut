using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class HaakEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Image ui;
    public bool hit;
    private void Update()
    {
        if (hit)
        {
            ui.gameObject.SetActive(true);
            ui.color = new UnityEngine.Color(ui.color.r, ui.color.g, ui.color.b, ui.color.a + Time.deltaTime);
        }
        if (ui.color.a >= 1)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            hit = true;
        }
    }
}
