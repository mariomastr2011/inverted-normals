using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;

    private List<GameObject> whiteCubes;
    private List<GameObject> greyCubes;

    private List<Vector3> whiteGoals;
    private List<Vector3> greyGoals;

    private bool isInverted = false;

    void Start()
    {
        whiteGoals = new List<Vector3>();
        greyGoals = new List<Vector3>();

        whiteCubes = GameManager.instance.GetWhiteCubes();
        greyCubes = GameManager.instance.GetGreyCubes();

        GameManager.instance.OnInverted += GameManager_OnInverted;

        InputManager.instance.Up += InputManager_Up;
        InputManager.instance.Down += InputManager_Down;
        InputManager.instance.Left += InputManager_Left;
        InputManager.instance.Right += InputManager_Right;

        foreach(GameObject gameObject in whiteCubes)
        {
            gameObject.transform.position = Misc.SnapPosition(gameObject.transform.position, 1);
            whiteGoals.Add(gameObject.transform.position);
        }

        foreach(GameObject gameObject in greyCubes)
        {
            gameObject.transform.position = Misc.SnapPosition(gameObject.transform.position, 1);
            greyGoals.Add(gameObject.transform.position);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    void FixedUpdate()
    {
        for(int i = 0; i < whiteCubes.Count; i++)
        {
            Rigidbody cubeRb = whiteCubes[i].GetComponent<Rigidbody>();
            if(cubeRb.position != whiteGoals[i])
            {
                cubeRb.MovePosition(Vector3.Lerp(cubeRb.position, whiteGoals[i], moveSpeed*Time.deltaTime));
            }
        }
    }

    private void InputManager_Right(object sender, EventArgs e)
    {
        Move(Vector3.right);
    }

    private void InputManager_Left(object sender, EventArgs e)
    {
        Move(Vector3.left);
    }

    private void InputManager_Down(object sender, EventArgs e)
    {
        Move(Vector3.back);
    }

    private void InputManager_Up(object sender, EventArgs e)
    {
        Move(Vector3.forward);
    }

    private void GameManager_OnInverted(object sender, EventArgs e)
    {
        isInverted = GameManager.instance.IsInverted();
    }

    private void Move(Vector3 direction)
    {
        for(int i = 0; i < whiteCubes.Count; i++)
        {
            Vector3 position = whiteCubes[i].transform.position;
            position += direction;
            position = Misc.SnapPosition(position, 1);
            whiteGoals[i] = position;
        }
    }
}
