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
    [SerializeField] EnvColorManager envColorManager;

    private bool isInverted = false;

    void Start()
    {
        envColorManager.SetColors(colorsList[0].color, colorsList[1].color);

        foreach(Colors color in colorsList)
        {
            foreach(GameObject box in color.boxes)
            {
                box.GetComponent<Renderer>().material.color = color.color;
            }
        }

        InputManager.instance.Inverted += InputManager_Inverted;
    }

    private void InputManager_Inverted(object sender, EventArgs e)
    {
        isInverted = !isInverted;
        if(isInverted)
        {
            ChangeEnvColor(colorsList[1].color);
        }
        else
        {
            ChangeEnvColor(colorsList[0].color);
        }
    }

    private void ChangeEnvColor(Color color){
        envColorManager.DoColorLerp(isInverted);
    }
}
