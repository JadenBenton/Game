using UnityEngine;

public class TerrtainGen : MonoBehaviour
{
    public int depth = 20;
    public int width = 256;
    public int height = 256;

    public float scale = 20;

    private void Start()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }
    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenHeights());
        return terrainData;
    }

    float[,] GenHeights()
    {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalcHeight(x, y);
            }
        }

        return heights;

    }
    float CalcHeight(int x, int y)
    {
        float xCrd = x / width * scale;
        float yCrd = y / height * scale;

        return Mathf.PerlinNoise(xCrd, yCrd);
    }
}