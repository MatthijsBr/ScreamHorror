using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] GameObject wall;

    List<List<bool>> horizontalWalls = new List<List<bool>>(3);
    List<List<bool>> verticalWalls = new List<List<bool>>(2);

    Vector3 horizontalWallOffset = new Vector3(0, 0.5f, 0.5f);
    Vector3 verticalWallOffset = new Vector3(0.5f, 0.5f, 0f);


    // Start is called before the first frame update
    void Start()
    {
        for (int y = 0; y < 3; y ++)
        {
            horizontalWalls.Add(new List<bool>(2));
            for (int x = 0; x < 2; x++)
            {
                horizontalWalls[y].Add(true);
            }
        }

        for (int y = 0; y < 2; y++)
        {
            verticalWalls.Add(new List<bool>(3));
            for (int x = 0; x < 3; x++)
            {
                verticalWalls[y].Add(true);
            }
        }

        Remove3Walls();
        GenerateMaze();
    }

    /// <summary>
    /// Generates the maze from walls
    /// </summary>
    private void GenerateMaze()
    {
        for (int x = 0; x < horizontalWalls.Count; x++)
            for (int z = 0; z < horizontalWalls[x].Count; z++)
                if (horizontalWalls[x][z])
                    Instantiate(wall, transform.position + horizontalWallOffset + new Vector3(x, 0, z), Quaternion.identity);

        for (int x = 0; x < verticalWalls.Count; x++)
            for (int z = 0; z < verticalWalls[x].Count; z++)
                if (verticalWalls[x][z])
                    Instantiate(wall, transform.position + verticalWallOffset + new Vector3(x, 0, z), Quaternion.Euler(0, 90, 0));
    }

    /// <summary>
    /// Destroy 3 walls of 3 random directions
    /// </summary>
    
    private void Remove3Walls()
    {
        // Choose 3 sides
        List<Vector2> sides = new List<Vector2> { Vector2.up, Vector2.down, Vector2.right, Vector2.left};
        sides.RemoveAt(Random.Range(0, 3));

        foreach (Vector2 side in sides)
        {
            Debug.Log(side);
            if (side.x == 0) // The wall is vertical
            {
                int x = (verticalWalls[0].Count - 1) / 2;
                int halfHeight = verticalWalls.Count / 2;
                int heightOffset = (int)((side.y + 1) / 2) * halfHeight;
                int randomHeight = Random.Range(0, halfHeight);
                int y = randomHeight + heightOffset;
                verticalWalls[y][x] = false;
            }

            if (side.y == 0) // The wall is horizontal
            {
                int y = (horizontalWalls.Count - 1) / 2;
                int halfWidth = horizontalWalls[0].Count / 2;
                int widthOffset = (int)((side.x + 1) / 2) * halfWidth;
                int randomWidth = Random.Range(0, halfWidth);
                int x = randomWidth + widthOffset;
                horizontalWalls[y][x] = false;
            }
        }
    }

    /*
    private void Duplicate3Times()
    {
        horizontalWalls = {
            { true, true },
            { true, true },
            { true, true }
        }; 
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
