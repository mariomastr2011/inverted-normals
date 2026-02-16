using UnityEngine;

public class EnvColorManager : MonoBehaviour
{
    private Color color1;
    private Color color2;
    private bool isInverted = false;

    [SerializeField] [Range(0f, 1f)] private float lerpTime = 1;
    [SerializeField] private float speedMultiplier = 0.5f;

    void Update()
    {
        

        if (!isInverted)
        {
            foreach(Transform transform in transform)
            {
                Color lerpedColor = Color.Lerp(transform.GetComponent<Renderer>().material.color, color1, lerpTime*Time.deltaTime*speedMultiplier);
                transform.GetComponent<Renderer>().material.color = lerpedColor;
            }
        }
        else
        {
            foreach(Transform transform in transform)
            {
                Color lerpedColor = Color.Lerp(transform.GetComponent<Renderer>().material.color, color2, lerpTime*Time.deltaTime*speedMultiplier);
                transform.GetComponent<Renderer>().material.color = lerpedColor;
            }
        }
    }

    public void SetColors(Color color1, Color color2)
    {
        foreach(Transform transform in transform)
        {
            transform.GetComponent<Renderer>().material.color = color1;
        }

        this.color1 = color1;
        this.color2 = color2;
    }

    public void DoColorLerp(bool inverted)
    {
        isInverted = inverted;
    }
}
