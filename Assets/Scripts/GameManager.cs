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

    public static GameManager instance;
    public event EventHandler OnInverted;

    private bool isInverted = false;

    void Awake()
    {
        instance = this;

        envColorManager.SetColors(colorsList[0].color, colorsList[1].color);

        foreach(Colors color in colorsList)
        {
            foreach(GameObject box in color.boxes)
            {
                box.GetComponent<Renderer>().material.color = color.color;
            }
        }
    }

    void Start()
    {
        InputManager.instance.Inverted += InputManager_Inverted;
    }

    private void InputManager_Inverted(object sender, EventArgs e)
    {
        isInverted = !isInverted;
        if(isInverted)
        {
            ChangeEnvColor(colorsList[0].color);
        }
        else
        {
            ChangeEnvColor(colorsList[1].color);
        }
        OnInverted?.Invoke(this, EventArgs.Empty);
    }

    private void ChangeEnvColor(Color color){
        envColorManager.DoColorLerp(isInverted);
    }

    public List<GameObject> GetWhiteCubes()
    {
        return colorsList[0].boxes;
    }

    public List<GameObject> GetGreyCubes()
    {
        return colorsList[1].boxes;
    }

    public bool IsInverted()
    {
        return isInverted;
    }
}
