using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHandler : MonoBehaviour {

    public int height = 5;
    public int width = 6;

    public GameObject square;
    public GameObject boundary;
    public GameObject gridParent;
    public GameObject boundaryParent;

    void Start() {
        GridCreate(width, height);
        SpawnSquares(width, height);
        SpawnBoundaries(width, height);
    }

    public IDictionary<string, string> grid = new Dictionary<string, string>();

    void GridCreate(int w, int h) {
        for(int i = 1; i <= w; i++) {
            for(int j = 1; j <= h; j++) {
                grid.Add((i.ToString() + "." + j.ToString()), "ensw.x");
            }
        }
        /*foreach(KeyValuePair<string, string> item in grid) {
            Debug.Log("Key: " + item.Key + ", Value: " + item.Value);
        }*/
    }

    void SpawnSquares(int w, int h) {
        float leftBound = -(w / 2f - .5f);
        float botBound = -(h / 2f - .5f);
        for(int i = 0; i < w; i++) {
            for(int j = 0; j < h; j++) {
                Instantiate(square, new Vector3((leftBound + i), (botBound + j), 0), Quaternion.identity, gridParent.transform);
            }
        }
    }

    void SpawnBoundaries(int w, int h) {
        float leftBound = -(w / 2f);
        float botBound = -(h / 2f);
        for(int i = 0; i <= w; i++) {
            for(int j = 0; j < h; j++) {
                Instantiate(boundary, new Vector3((leftBound + i), (botBound + j + .5f), 0), Quaternion.identity, boundaryParent.transform);
            }
        }
        for(int i = 0; i < w; i++) {
            for(int j = 0; j <= h; j++) {
                Instantiate(boundary, new Vector3((leftBound + i + .5f), (botBound + j), 0), Quaternion.Euler(0, 0, 90), boundaryParent.transform);
            }
        }
    }

    void Grouping(string startKey) {
        //e and w, n and s
        string[] tiles = { startKey };
        foreach(string tile in tiles) {
            //
        }
    }

    //retrieves the wanted piece from the pair
    public string WantedValue(string key, int pieceNum) {
        //0 is closed directions, 1 is pen
        string value = grid[key];
        string[] values = value.Split('.');
        string piece = values[pieceNum];
        return piece;
    }

    //combines the new piece with the old piece from the key for a new value
    public void Reconstruct(string key, string piece, int pieceNum) {
        string value = grid[key];
        string[] values = value.Split('.');
        values[pieceNum] = piece;
        //print("piece is now " + values[pieceNum] + ". Should be " + piece);
        string whole = values[0] + "." + values[1];
        //print("whole is now " + whole);
        grid[key] = whole;
    }

    //changes one character of the first value according to request then returns it so it can be put into Reconstruct
    //used to add/remove a single boundary at a time
    public string UpdateCode(string key, char aOrR, char chara) {
        string template = "ensw";
        string value = grid[key];
        string[] values = value.Split('.');
        string newPiece = "";
        if(aOrR == 'r') {
            //print("removing char " + chara);
            foreach(char c in values[0]) {
                if(c != chara) {
                    newPiece += c;
                }
            }
        } else if(aOrR == 'a') {
            //print("adding char " + chara);
            foreach(char c in template) {
                if(values[0].Contains(c.ToString()) || chara == c) {
                    newPiece += c;
                }
            }
        } else {
            print("error updating grid value (UpdateCode). check your scripts");
        }
        return newPiece;
    }
}
