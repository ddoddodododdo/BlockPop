using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEffect : MonoBehaviour
{
    public SpriteRenderer sr;

    private Color applyColor;
    private Vector3 addScale;

    private void Awake()
    {
        applyColor = sr.color;
        addScale = Vector3.one * 0.01f;
    }

    private void FixedUpdate()
    {
        applyColor.a -= 0.01f;
        sr.color = applyColor;

        transform.position += addScale;

        if (applyColor.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
