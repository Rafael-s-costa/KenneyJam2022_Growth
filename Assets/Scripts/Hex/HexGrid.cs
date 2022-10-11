using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    [SerializeField]
    private GameObject emptyHexPrefab;

    [SerializeField]
    private GameObject castlePrefab;

    [SerializeField]
    private GameObject farmPrefab;

    [SerializeField]
    private GameObject forestPrefab;

    [SerializeField]
    private GameObject millPrefab;

    [SerializeField]
    private GameObject riverPrefab;

    [SerializeField]
    private GameObject townPrefab;

    [SerializeField]
    private GameObject waterMillPrefab;

    public GameObject SpawnHex(string hexName, Transform transform)
    {
        return Instantiate(
            GetHexPrefabByName(hexName), 
            transform.position, 
            transform.rotation, 
            gameObject.transform
        );
    }

    public void SpawnNeighbouringEmptyHexes(Transform hexTransform)
    {
        for (int i = 0; i < HexMath.cardinalDirections.Length; i++)
        {
            Vector2 offset;
            HexMath.cardinalDistances.TryGetValue(HexMath.cardinalDirections[i], out offset);

            Collider[] intersecting = Physics.OverlapSphere(hexTransform.position + new Vector3(offset.x, 0, offset.y), 0.001f);

            if (intersecting.Length == 0)
            {
                GameObject newHex = Instantiate(
                    emptyHexPrefab,
                    (hexTransform.position + new Vector3(offset.x, 0, offset.y)),
                    hexTransform.rotation, gameObject.transform)
                ;

                SetNeighbouringHexes(
                    hexTransform.gameObject.GetComponent<Hex>(), 
                    i, 
                    newHex.GetComponent<Hex>()
                );
            }
        }
    }

    private GameObject GetHexPrefabByName(string name)
    {
        IDictionary<string, GameObject> prefabMap = new Dictionary<string, GameObject>()
        {
            { "empty", emptyHexPrefab },
            { "castle", castlePrefab },
            { "farm", farmPrefab },
            { "forest", forestPrefab },
            { "mill", millPrefab },
            { "river", riverPrefab },
            { "town", townPrefab },
            { "water-mill", waterMillPrefab }
        };

        return prefabMap[name];
    }

    private void SetNeighbouringHexes(Hex originalHex, int cardinalDirectionindex, Hex newHex)
    {
        originalHex.neighbours.Add(HexMath.cardinalDirections[cardinalDirectionindex], newHex);
        newHex.neighbours.Add(HexMath.GetOpositeCardinalDirection(cardinalDirectionindex), originalHex);
    }
}
