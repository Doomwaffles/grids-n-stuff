using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour {
    
    private void Update() {
        if(Input.GetMouseButtonUp(0)) {
            //print("mouse down");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //print(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (hit) {
                Activate(hit);
                //print("hit");
            }
        }
    }

    void Activate(RaycastHit2D h) {
        if(h.transform.tag == "boundary") {
            h.transform.GetComponent<BoundaryScript>().Flip();
        }
    }
}
