using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimToUI : MonoBehaviour
{
    void Update()
    {
        GetComponent<Image>().sprite = GetComponent<SpriteRenderer>().sprite;
    }
}
