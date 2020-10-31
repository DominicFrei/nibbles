using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerLoot : MonoBehaviour
{
    [SerializeField] Loot lootPrefab = default;    

    void Awake()
    {
        if (!lootPrefab)
        {
            Debug.Log("lootPrefab must not be null.");
        }
    }

    public void SpawnLoot()
    {
        List<Vector3> availablePositions = GenerateMapWithUnoccupiedPostions();
        if (availablePositions.Count != 0)
        {
            int randomLocationIndex = Random.Range(0, availablePositions.Count);
            Vector3 lootSpawnPosition = availablePositions[randomLocationIndex];
            _ = Instantiate(lootPrefab, lootSpawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.Log("No unoccupied positions left. Player won.");
        }
    }

    // Creates a new map (2-dimensional array) with the playing field which will be used to check
    // if a position is already used or not in order to spawn loot only at unoccupied positions.
    List<Vector3> GenerateMapWithUnoccupiedPostions()
    {
        int width = GameplayConstants.MapBounds.Right - GameplayConstants.MapBounds.Left + 1;
        int height = GameplayConstants.MapBounds.Upper - GameplayConstants.MapBounds.Lower + 1;

        List<Vector3> availablePositions = new List<Vector3>();

        for (int i = 0; i < width + 1; i++)
        {
            for (int j = 0; j < height + 1; j++)
            {
                Vector3 position = new Vector3(i, j, 0.0f);
                Collider[] otherObjectsInSpawnLocation = Physics.OverlapSphere(position, 0.25f);
                bool positionIsUnoccupied = otherObjectsInSpawnLocation.Length == 0;
                if (positionIsUnoccupied)
                {
                    availablePositions.Add(position);
                }
            }
        }
        return availablePositions;
    }

}
