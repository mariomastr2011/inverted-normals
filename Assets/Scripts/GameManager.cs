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

    void Start()
    {
        foreach(Colors color in colorsList)
        {
            Debug.Log(color.color);
        }
    }
}
