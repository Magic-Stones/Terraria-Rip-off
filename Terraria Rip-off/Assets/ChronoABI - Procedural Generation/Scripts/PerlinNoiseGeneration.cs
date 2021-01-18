using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PerlinNoiseGeneration : MonoBehaviour
{
    public int width;
    public Tilemap dirtTile, grassTile, stoneTile;
    public Tile dirtBlock, grassBlock, stoneBlock;

    public int setMinGenerateStone, setMaxGenerateStone;

    [Range(0, 50)]
    public float height, generationSmoothness;

    public float generateSeed;

    private int heightValue;
    private int minGenStoneBlock, maxGenStoneBlock, generateStoneBlock;

    private bool renew = false;

    // Start is called before the first frame update
    void Start()
    {
        generateSeed = Random.Range(-10000, 10000);
        ProceduralGeneration();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            renew = !renew;

            if (renew)
            {
                generateSeed = Random.Range(-10000, 10000);
                ProceduralGeneration();
            }
            else
            {
                dirtTile.ClearAllTiles();
                grassTile.ClearAllTiles();
                stoneTile.ClearAllTiles();
            }
        }
    }

    private void ProceduralGeneration()
    {
        for (int x = 0; x < width; x++)
        {
            heightValue = Mathf.RoundToInt(height * Mathf.PerlinNoise(x / generationSmoothness, generateSeed));

            minGenStoneBlock = heightValue - setMinGenerateStone;
            maxGenStoneBlock = heightValue - setMaxGenerateStone;
            generateStoneBlock = Random.Range(minGenStoneBlock, maxGenStoneBlock);

            for (int y = 0; y < heightValue; y++)
            {
                if (y < generateStoneBlock)
                {
                    stoneTile.SetTile(new Vector3Int(x, y, 0), stoneBlock);
                }

                dirtTile.SetTile(new Vector3Int(x, y, 0), dirtBlock);
            }

            if (generateStoneBlock == heightValue)
            {
                stoneTile.SetTile(new Vector3Int(x, heightValue, 0), stoneBlock);
            }

            grassTile.SetTile(new Vector3Int(x, heightValue, 0), grassBlock);
        }
    }
}
