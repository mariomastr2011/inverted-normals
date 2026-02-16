using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    class Colors
    {
        public Color color;
        public List<GameObject> boxes;
    }

    [SerializeField] List<Colors> colorsList;
    [SerializeField] Transform environmentParent;

    private Dictionary<int, Color> colorsDict = new Dictionary<int, Color>();
    private int currentColorIndex = 0;

    void Start()
    {
        foreach(Transform envTransform in environmentParent)
        {
            envTransform.gameObject.GetComponent<Renderer>().material.color = colorsList[currentColorIndex].color;
        }

        int i = 0;
        foreach(Colors color in colorsList)
        {
            colorsDict.Add(i, color.color);
            i++;

            foreach(GameObject box in color.boxes)
            {
                box.GetComponent<Renderer>().material.color = color.color;
            }
        }

        InputManager.instance.Inverted += InputManager_Inverted;
    }

    private void InputManager_Inverted(object sender, EventArgs e)
    {
        currentColorIndex++;
        if(currentColorIndex > colorsList.Count - 1)
        {
            currentColorIndex = 0;
        }

        Debug.Log(currentColorIndex);
        Debug.Log(colorsList.Count - 1);

        foreach(Transform envTransform in environmentParent)
        {
            envTransform.gameObject.GetComponent<Renderer>().material.color = colorsList[currentColorIndex++].color;
        }
    }
}
