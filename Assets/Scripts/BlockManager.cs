using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public const int MAX_BLOCK_COUNT = 10;
    public GameManager gameManager;
    public GameObject[] spawnPoses;
    public GameObject[] blocks;

    [HideInInspector] public Queue<int> blockData;

    private GameObject[] leftBlocks;
    private GameObject[] rightBlocks;

    private Vector3 spawnPos;
    private int firstData;
    private int leftIndex;
    private int rightIndex;

    private void Awake()
    {
        SetBlockHeight();
        MakeBlock();
    }

    private void OnEnable()
    {
        StartGame();
    }

    public void StartGame()
    {
        MakeBlockData();
    }

    private void SetBlockHeight()
    {
        float y1 = spawnPoses[0].transform.position.y;
        float y2 = spawnPoses[1].transform.position.y;

        BlockSize.height = y1 - y2;
    }

    private void MakeBlock()
    {
        int length = MAX_BLOCK_COUNT;
        leftBlocks = new GameObject[length];
        rightBlocks = new GameObject[length];

        for (int i = 0; i < length; i++)
        {
            leftBlocks[i] = Instantiate(blocks[0], transform);
        }

        for (int i = 0; i < length; i++)
        {
            rightBlocks[i] = Instantiate(blocks[1], transform);
        }
    }

    private void MakeBlockData()
    {
        blockData = new Queue<int>();

        for(int i = 0; i < MAX_BLOCK_COUNT; i++)
        {
            blockData.Enqueue(Random.Range(0, 2));
        }
        SetBlock();
    }

    private void SetBlock()
    {
        spawnPos = spawnPoses[0].transform.position;
        leftIndex = 0;
        rightIndex = 0;

        foreach (int num in blockData)
        {
            if(num == 0)
            {
                leftBlocks[leftIndex].transform.position = spawnPos;
                leftIndex++;
            }
            else
            {
                rightBlocks[rightIndex].transform.position = spawnPos;
                rightIndex++;
            }
            spawnPos.y -= BlockSize.height;
        }
        OrganizeBlock();
    }

    private void OrganizeBlock()
    {
        for(int i = leftIndex; i < leftBlocks.Length; i++)
        {
            leftBlocks[i].transform.position = spawnPos;
        }

        for (int i = rightIndex; i < rightBlocks.Length; i++)
        {
            rightBlocks[i].transform.position = spawnPos;
        }
    }

    public bool TryBreakBlock(int dir)
    {
        if(dir == blockData.Peek())
        {
            BreakBlock();
            return true;
        }

        return false;
    }

    private void BreakBlock()
    {
        int num = blockData.Dequeue();

        blockData.Enqueue(Random.Range(0, 2));
        SetBlock();
        gameManager.UpScore();
        SoundManager.instance.blockPopSound.Play();
    }
}
