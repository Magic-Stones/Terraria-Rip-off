using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    public int width, height;
    public GameObject dirtBlock, grassBlock;

    public int setRepeatBlocks;

    public int setMinHeight, setMaxHeight;

    private int minHeight, maxHeight;
    private int repeatBlocks;

    // Start is called before the first frame update
    void Start()
    {
        GeneratePlatform();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GeneratePlatform()
    {
        repeatBlocks = 0;

        for(int x = 0; x < width; x++)
        {
            minHeight = height - setMinHeight;
            maxHeight = height + setMaxHeight;
            // height = Random.Range(minHeight, maxHeight);
            
            if (repeatBlocks == 0)
            {
                height = Random.Range(minHeight, maxHeight);
                GeneratePlatformBlocks(x);
                repeatBlocks = setRepeatBlocks;
            }
            else
            {
                GeneratePlatformBlocks(x);
                repeatBlocks--;
            }
        }
    }

    private void GenerateBlock(GameObject block, int x, int y) 
    {
        block = Instantiate(block, new Vector2(x, y), Quaternion.identity);
        block.transform.parent = this.transform;
    }

    private void GeneratePlatformBlocks(int x)
    {
        for (int y = 0; y < height; y++)
        {
            GenerateBlock(dirtBlock, x, y);
        }

        GenerateBlock(grassBlock, x, height);
    }
}
