using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class SOTest : MonoBehaviour
{
    // Start is called before the first frame update

    public Coordinates coord;
    public GameObject[] tiles;
    public bool reverse;

    private int[] lineNum = { 1, 3, 6, 10, 15, 21, 28, 36, 45, 54, 63, 72, 81, 90, 99, 108, 116, 123, 129, 134, 138, 141, 143, 144};
    private int num = 0;
    private int index = 0;

    void Start() {
        /*for(int i = tiles.Length - 1; i >= 0; i--) {
            RectTransform rt = tiles[i].GetComponent<RectTransform>();
            coord.sceneTransitionObjects[i].transitionObject = tiles[i];
            coord.sceneTransitionObjects[i].targetPoint = rt.localPosition;
            coord.sceneTransitionObjects[i].order = index;
            num++;
            for(int j = 0; j < lineNum.Length; j++) {
                if(lineNum[j] <= num) {
                    index = j + 1;
                }
            }
        }*/
        // for (int i = tiles.Length - 1; i >= 0; i--) {
        for (int i = 0; i < tiles.Length; i++) {
            RectTransform rt = tiles[i].GetComponent<RectTransform>();
            coord.sceneTransitionObjects[i].transitionObject = tiles[i];
            coord.sceneTransitionObjects[i].targetPoint = new Vector3(0, 0, 0);
            coord.sceneTransitionObjects[i].order = index;
            coord.sceneTransitionObjects[i].order = index;
            num++;
            for (int j = 0; j < lineNum.Length; j++) {
                if (lineNum[j] <= num) {
                    index = j + 1;
                }
            }
        }
    }
}
