using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcGenBeginners : MonoBehaviour
{
    public int width, height;
    public GameObject dirtBlock, grassBlock, stoneBlock;

    public int setMinHeight, setMaxHeight;

    private int minHeight, maxHeight;
    private int minGenStoneBlock, maxGenStoneBlock, generateStoneBlock;

    public int setMinGenerateStone, setMaxGenerateStone;

    // Start is called before the first frame update
    void Start()
    {
        ProceduralGeneration();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ProceduralGeneration()
    {
        for(int x = 0; x < width; x++)
        {
            minHeight = height - setMinHeight;
            maxHeight = height + setMaxHeight;
            height = Random.Range(minHeight, maxHeight);

            minGenStoneBlock = height - setMinGenerateStone;
            maxGenStoneBlock = height - setMaxGenerateStone;
            generateStoneBlock = Random.Range(minGenStoneBlock, maxGenStoneBlock);

            for (int y = 0; y < height; y++)
            {
                if (y < generateStoneBlock)
                {
                    generateBlock(stoneBlock, x, y);
                }

                generateBlock(dirtBlock, x, y);
            }

            if (generateStoneBlock == height)
            {
                generateBlock(stoneBlock, x, height);
            }

            generateBlock(grassBlock, x, height);
        }
    }

    private void generateBlock(GameObject block, int x, int y)
    {
        block = Instantiate(block, new Vector2(x, y), Quaternion.identity);
        block.transform.parent = this.transform;
    }
}
