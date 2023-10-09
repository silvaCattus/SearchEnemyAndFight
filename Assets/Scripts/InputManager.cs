using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameStateController fsm = null;

    private void Update()
    {
        if (fsm.CurrentState is FightState)
        {
#if UNITY_EDITOR
            CheckTouchEditor();
#endif
            CheckTouch();
        }
    }

    private void CheckTouch()
    {
        if (Input.touchCount > 0)
        {
            var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.transform.GetComponent<Enemy>())
                {
                    hit.transform.GetComponent<Enemy>().SetDamage();
                }
            }
        }
    }
    private void CheckTouchEditor()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero);

            if(hit.collider != null)
            {
                if (hit.transform.GetComponent<Enemy>())
                {
                    hit.transform.GetComponent<Enemy>().SetDamage();
                }
            }
        }
    }
}
