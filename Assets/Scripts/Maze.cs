using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    public bool[] walls;
    public bool visited;

    public Maze()
    {
        walls = new bool[6] { true, true, true, true, true, true };
        visited = false;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}