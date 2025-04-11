using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TerrainChecker
{
    private float[] GetTextureMix(Vector3 playerPos, Terrain t)
    {
        Vector3 tPos = t.transform.position;
        TerrainData tData = t.terrainData;
        int mapX = Mathf.RoundToInt((playerPos.x - tPos.x) / tData.size.x * tData.alphamapWidth);
        int mapZ = Mathf.RoundToInt((playerPos.z - tPos.z) / tData.size.z * tData.alphamapHeight);
        float[,,] splatMapData = tData.GetAlphamaps(mapX, mapZ, 1, 1);

        float[] cellmix = new float[splatMapData.GetUpperBound(2) + 1];

        for (int i = 0; i < cellmix.Length; i++)
        {
            cellmix[i] = splatMapData[0, 0, i];
        }
        return cellmix;
    }

    public string GetLayerName(Vector3 playerPos, Terrain t)
    {
        float[] cellmix = GetTextureMix(playerPos, t);
        int maxIndex = 0;
        float maxValue = cellmix[0];

        for (int i = 1; i < cellmix.Length; i++)
        {
            if (cellmix[i] > maxValue)
            {
                maxValue = cellmix[i];
                maxIndex = i;
            }
        }

        return t.terrainData.terrainLayers[maxIndex].name;
    }
}
