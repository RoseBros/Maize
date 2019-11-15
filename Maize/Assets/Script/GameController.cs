using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(MazeConstructor))]
public class GameController : MonoBehaviour
{
    private MazeConstructor generator;
    private void Start()
    {
        generator = GetComponent<MazeConstructor>();
        generator.GenerateNewMaze(31, 41);
    }
}
