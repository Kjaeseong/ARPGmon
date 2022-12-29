using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField] private GameObject _lockOnTarget;


    private void FixedUpdate() 
    {
        TargetLockOn();
    }

    private void TargetLockOn()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if(Physics.Raycast(ray, out hit))
                {
                    _lockOnTarget = hit.transform.gameObject;
                }
            }
        }
    }
}
