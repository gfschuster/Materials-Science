using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubicBodyCentered : MonoBehaviour
{
    public GameObject atomPrefab;
    public float cubeSize = 1.0f;
    public float yOffset = 2.0f; // Deslocamento em Y
    private List<Vector3> atomPositions = new List<Vector3>();
    private Vector3 centerPosition;

    void Start()
    {
        // Posições dos 8 vértices com deslocamento em Y
        Vector3[] positions = {
            new Vector3(0, yOffset, 0),
            new Vector3(cubeSize, yOffset, 0),
            new Vector3(0, cubeSize + yOffset, 0),
            new Vector3(0, yOffset, cubeSize),
            new Vector3(cubeSize, cubeSize + yOffset, 0),
            new Vector3(0, cubeSize + yOffset, cubeSize),
            new Vector3(cubeSize, yOffset, cubeSize),
            new Vector3(cubeSize, cubeSize + yOffset, cubeSize)
        };

        foreach (Vector3 pos in positions)
        {
            Instantiate(atomPrefab, pos, Quaternion.identity);
            atomPositions.Add(pos); // Armazena as posições
        }

        // Posição do átomo central com deslocamento em Y
        centerPosition = new Vector3(cubeSize / 2, cubeSize / 2 + yOffset, cubeSize / 2);
        Instantiate(atomPrefab, centerPosition, Quaternion.identity);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        if (atomPositions.Count == 8)
        {
            DrawCubeEdges();
            foreach (var pos in atomPositions)
            {
                Gizmos.DrawLine(pos, centerPosition); // Conecta os vértices ao centro
            }
        }
    }

    void DrawCubeEdges()
    {
        Gizmos.DrawLine(atomPositions[0], atomPositions[1]);
        Gizmos.DrawLine(atomPositions[0], atomPositions[2]);
        Gizmos.DrawLine(atomPositions[0], atomPositions[3]);
        Gizmos.DrawLine(atomPositions[1], atomPositions[4]);
        Gizmos.DrawLine(atomPositions[1], atomPositions[6]);
        Gizmos.DrawLine(atomPositions[2], atomPositions[4]);
        Gizmos.DrawLine(atomPositions[2], atomPositions[5]);
        Gizmos.DrawLine(atomPositions[3], atomPositions[6]);
        Gizmos.DrawLine(atomPositions[3], atomPositions[5]);

        Gizmos.DrawLine(atomPositions[4], atomPositions[7]);
        Gizmos.DrawLine(atomPositions[5], atomPositions[7]);
        Gizmos.DrawLine(atomPositions[6], atomPositions[7]);
    }
}
