using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using StarterAssets;
public class FootstepSwapper : MonoBehaviour
{
    private TerrainChecker terrainChecker;
    private FirstPersonController playerController;
    private string currentTerrainLayerName;

    public FootstepCollection[] terrainFootstepCollection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        terrainChecker = new TerrainChecker();
        playerController = GetComponent<FirstPersonController>();
        
    }

    public void checkLayer(){
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 3f))
        {
            if (hit.transform.GetComponent<Terrain>() != null)
            {
                Terrain t = hit.transform.GetComponent<Terrain>();
                if (currentTerrainLayerName != terrainChecker.GetLayerName(transform.position, t))
                {
                    currentTerrainLayerName = terrainChecker.GetLayerName(transform.position, t);
                    foreach (FootstepCollection collection in terrainFootstepCollection)
                    {
                        if (collection.name == currentTerrainLayerName)
                        {
                            playerController.SwapFootsteps(collection);
                            break;
                        }
                    }
                }
            }
        }
    }
}
