using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareScript : MonoBehaviour {

    Vector3 coords;
    GridHandler gh;
    string[] colorLibrary = { "e", "r", "b", "g" };
    public string key;

    private void Start() {
        gh = Camera.main.GetComponent<GridHandler>();
        coords = transform.position;
        int xCode = (int)(coords.x + .5f + (gh.width / 2f));
        int yCode = (int)(coords.y + .5f + (gh.height / 2f));
        key = xCode.ToString() + "." + yCode.ToString();
        //print("Coordinate: " + key);
    }

    public void CycleColor() {
        /*string val = gh.grid[key];
        int index = Array.IndexOf(colorLibrary, val);
        if(index < 3) {
            index++;
        } else {
            index = 0;
        }
        gh.grid[key] = colorLibrary[index];

        switch(colorLibrary[index]) {
            case "e":
                GetComponent<SpriteRenderer>().color = Color.black;
                break;
            case "r":
                GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case "b":
                GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case "g":
                GetComponent<SpriteRenderer>().color = Color.green;
                break;
            default:
                break;
        }*/
    }
}
