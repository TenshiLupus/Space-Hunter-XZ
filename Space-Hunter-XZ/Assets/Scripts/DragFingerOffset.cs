﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFingerOffset : MonoBehaviour
{
    private float deltaX, deltaY;
    private Rigidbody2D rigidbody;

    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update(){

        if (Input.touchCount>0){
            
            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase){
                case TouchPhase.Began:
                    deltaX = touchPos.x - transform.position.x;
                    deltaY = touchPos.y - transform.position.y;
                    break;
                
                case TouchPhase.Moved:
                    rigidbody.MovePosition(new Vector2(touchPos.x-deltaX, touchPos.y - deltaY));
                    break;

                case TouchPhase.Ended:
                    rigidbody.velocity = Vector2.zero;
                    break;
            }    
        }
    }
}
