using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour {

    Vector3 coords;
    bool vertical;
    GridHandler gh;
    public string keyOne;
    public string keyTwo;

    private void Start() {
        gh = Camera.main.GetComponent<GridHandler>();
        coords = transform.position;

        if(transform.eulerAngles.z >= 85 && transform.eulerAngles.z <= 95) {
            vertical = false;
        } else {
            vertical = true;
        }

        //find the keys
        if(vertical == true) {

            int yCode = (int)(coords.y + 0.5f + (gh.height / 2f));
            int xCodeOne = (int)(coords.x + (gh.width / 2f));
            int xCodeTwo = (int)(coords.x + 1f + (gh.width / 2f));
            keyOne = xCodeOne.ToString() + "." + yCode.ToString();
            keyTwo = xCodeTwo.ToString() + "." + yCode.ToString();
        } else {
            int xCode = (int)(coords.x + 0.5f + (gh.width / 2f));
            int yCodeOne = (int)(coords.y + (gh.height / 2f));
            int yCodeTwo = (int)(coords.y + 1f + (gh.height / 2f));
            keyOne = xCode.ToString() + "." + yCodeOne.ToString();
            keyTwo = xCode.ToString() + "." + yCodeTwo.ToString();
        }
        //print("Boundaries: " + keyOne + ", " + keyTwo);
    }

    public void Flip() {
        GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
        if(GetComponent<SpriteRenderer>().enabled == true) {
            if(vertical == true) {
                if(gh.grid.ContainsKey(keyOne)) {
                    gh.Reconstruct(keyOne, gh.UpdateCode(keyOne, 'a', 'e'), 0);
                }
                if(gh.grid.ContainsKey(keyTwo)) {
                    gh.Reconstruct(keyTwo, gh.UpdateCode(keyTwo, 'a', 'w'), 0);
                }
            } else {
                if(gh.grid.ContainsKey(keyOne)) {
                    gh.Reconstruct(keyOne, gh.UpdateCode(keyOne, 'a', 'n'), 0);
                }
                if(gh.grid.ContainsKey(keyTwo)) {
                    gh.Reconstruct(keyTwo, gh.UpdateCode(keyTwo, 'a', 's'), 0);
                }
            }
        } else {
            if(vertical == true) {
                if(gh.grid.ContainsKey(keyOne)) {
                    gh.Reconstruct(keyOne, gh.UpdateCode(keyOne, 'r', 'e'), 0);
                }
                if(gh.grid.ContainsKey(keyTwo)) {
                    gh.Reconstruct(keyTwo, gh.UpdateCode(keyTwo, 'r', 'w'), 0);
                }
            } else {
                if(gh.grid.ContainsKey(keyOne)) {
                    gh.Reconstruct(keyOne, gh.UpdateCode(keyOne, 'r', 'n'), 0);
                }
                if(gh.grid.ContainsKey(keyTwo)) {
                    gh.Reconstruct(keyTwo, gh.UpdateCode(keyTwo, 'r', 's'), 0);
                }
            }
        }
        print("Changed key: " + keyOne + ", New Value: " + gh.grid[keyOne]);
        print("Changed key: " + keyTwo + ", New Value: " + gh.grid[keyTwo]);
    }
}
