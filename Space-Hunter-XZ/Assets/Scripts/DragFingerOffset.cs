using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary{
    public float xMin, xMax, yMin, yMax;
}
public class DragFingerOffset : MonoBehaviour
{
    private float deltaX, deltaY;
    private Rigidbody rigidbody;
    public Boundary boundary;
    public float moveSpeed;


    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update(){

        if (Input.touchCount>0){
            
            Touch touch = Input.GetTouch(0);

            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            rigidbody.position = new Vector3(
                Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp (rigidbody.position.y, boundary.yMin, boundary.yMax), 0
            );

            switch (touch.phase){
                case TouchPhase.Began:
                    deltaX = touchPos.x - transform.position.x;
                    deltaY = touchPos.y - transform.position.y;
                    break;
                
                case TouchPhase.Moved:
                    rigidbody.velocity = new Vector3(touchPos.x-deltaX, touchPos.y - deltaY, 0)* moveSpeed;
                    break;

                case TouchPhase.Ended:
                    rigidbody.velocity = Vector2.zero;
                    break;
            }    
        }
    }
}
