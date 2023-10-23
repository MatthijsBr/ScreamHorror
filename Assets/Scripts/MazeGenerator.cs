using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.AI;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] GameObject wall;

    List<List<bool>> horizontalWalls;
    List<List<bool>> verticalWalls;

    [SerializeField] Vector3 horizontalWallOffset = new Vector3(0, 0.5f, 0.5f);
    [SerializeField] Vector3 verticalWallOffset = new Vector3(0.5f, 0.5f, 0f);


    // Start is called before the first frame update
    void Start()
    {

    }



    public void GenerateMaze()
    {
        ResetMaze();
        Remove3Walls();
        Duplicate3Times();
        Remove3Walls();
        Duplicate3Times();
        Remove3Walls();
        DeleteMiddle2x2();
        DeleteOuterWalls();
        CreatePhysicalLevel();
    }

    private void DeleteOuterWalls()
    {
        // Destroy East and West outer walls
        foreach(List<bool> row in verticalWalls)
        {
            row[0] = false;
            row[row.Count - 1] = false;
        }

        // Destroy North and South outer walls
        for(int x = 0; x < horizontalWalls[0].Count; x++)
        {
            horizontalWalls[0][x] = false;
            horizontalWalls[horizontalWalls.Count - 1][x] = false;
        }

    }

    private void ResetMaze()
    {
        horizontalWalls = new List<List<bool>>(3);

        for (int y = 0; y < 3; y++)
        {
            horizontalWalls.Add(new List<bool>(2));
            for (int x = 0; x < 2; x++)
            {
                horizontalWalls[y].Add(true);
            }
        }

        verticalWalls = new List<List<bool>>(2);

        for (int y = 0; y < 2; y++)
        {
            verticalWalls.Add(new List<bool>(3));
            for (int x = 0; x < 3; x++)
            {
                verticalWalls[y].Add(true);
            }
        }
    }

    private void DeleteMiddle2x2()
    {
        int middleColumnX = Mathf.FloorToInt(verticalWalls[0].Count / 2);
        int startingY = verticalWalls.Count / 2 - 1;
        for (int x = middleColumnX - 1; x <= middleColumnX + 1; x++)
            for (int y = startingY; y < startingY + 2; y++)
                verticalWalls[y][x] = false;

        int middleRowY = Mathf.FloorToInt(horizontalWalls.Count / 2);
        int startingX = horizontalWalls[0].Count / 2 - 1;
        for (int y = middleRowY - 1; y <= middleRowY + 1; y++)
            for (int x = startingX; x < startingX + 2; x++)
                horizontalWalls[y][x] = false;
    }

    /// <summary>
    /// Generates the maze from walls
    /// </summary>
    private void CreatePhysicalLevel()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int x = 0; x < horizontalWalls.Count; x++)
            for (int z = 0; z < horizontalWalls[x].Count; z++)
                if (horizontalWalls[x][z])
                    Instantiate(wall, transform.position + horizontalWallOffset + new Vector3(x, 0, z), Quaternion.identity, transform);

        for (int x = 0; x < verticalWalls.Count; x++)
            for (int z = 0; z < verticalWalls[x].Count; z++)
                if (verticalWalls[x][z])
                    Instantiate(wall, transform.position + verticalWallOffset + new Vector3(x, 0, z), Quaternion.Euler(0, 90, 0), transform);
    }

    /// <summary>
    /// Destroy 3 walls of 3 random directions
    /// </summary>
    private void Remove3Walls()
    {
        // Choose 3 sides
        List<Vector2> sides = new List<Vector2> { Vector2.up, Vector2.down, Vector2.right, Vector2.left };
        sides.RemoveAt(Random.Range(0, 3));

        foreach (Vector2 side in sides)
        {
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


    private void Duplicate3Times()
    {
        // First, copy to the right
        int width = horizontalWalls[0].Count;

        foreach (List<bool> row in horizontalWalls)
            for (int i = 0; i < width; i++)
                row.Add(row[i]);

        foreach (List<bool> row in verticalWalls)
            for (int i = 0; i < width; i++)
                row.Add(row[i + 1]); //Offset by one, because we don't want to duplicate the leftmost wall

        // Then, copy down
        int height = verticalWalls.Count;

        for (int i = 0; i < height; i++)
        {
            List<bool> newVerticalRow = new List<bool>(verticalWalls[i]);
            verticalWalls.Add(newVerticalRow);

            List<bool> newHorizontalRow = new List<bool>(horizontalWalls[i + 1]); // Offset by one, to not copy uppermost wall
            horizontalWalls.Add(newHorizontalRow);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GenerateMaze();
        }
    }
}

