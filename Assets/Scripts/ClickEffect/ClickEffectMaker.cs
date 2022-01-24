using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEffectMaker : MonoBehaviour
{
    public GameObject clickEffectObject;

    private Touch nowTouch;
    private Vector3 spawnPos;

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    spawnPos.z = 0;
        //    Instantiate(clickEffectObject, spawnPos, Quaternion.identity);
        //}

        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                nowTouch = Input.GetTouch(i);

                if (nowTouch.phase != TouchPhase.Began) 
                    continue;

                spawnPos = Camera.main.ScreenToWorldPoint(nowTouch.position);
                spawnPos.z = 0;
                Instantiate(clickEffectObject, spawnPos, Quaternion.identity);
            }
        }
    }


    
}
