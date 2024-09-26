using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubicFaceCentered : MonoBehaviour
{
    public GameObject atomPrefab;
    public float cubeSize = 1.0f;
    public float yOffset = 2.0f; // Deslocamento em Y
    private List<Vector3> atomPositions = new List<Vector3>();
    private List<Vector3> faceCenterPositions = new List<Vector3>();

    void Start()
    {
        // Posições dos 8 vértices com deslocamento em Y
        Vector3[] vertexPositions = {
            new Vector3(0, yOffset, 0),
            new Vector3(cubeSize, yOffset, 0),
            new Vector3(0, cubeSize + yOffset, 0),
            new Vector3(0, yOffset, cubeSize),
            new Vector3(cubeSize, cubeSize + yOffset, 0),
            new Vector3(0, cubeSize + yOffset, cubeSize),
            new Vector3(cubeSize, yOffset, cubeSize),
            new Vector3(cubeSize, cubeSize + yOffset, cubeSize)
        };

        // Posições dos centros das faces com deslocamento em Y
        Vector3[] faceCenters = {
            new Vector3(cubeSize / 2, cubeSize / 2 + yOffset, 0),        // Frente
            new Vector3(cubeSize / 2, cubeSize / 2 + yOffset, cubeSize), // Trás
            new Vector3(0, cubeSize / 2 + yOffset, cubeSize / 2),        // Esquerda
            new Vector3(cubeSize, cubeSize / 2 + yOffset, cubeSize / 2), // Direita
            new Vector3(cubeSize / 2, yOffset, cubeSize / 2),            // Baixo
            new Vector3(cubeSize / 2, cubeSize + yOffset, cubeSize / 2)  // Cima
        };

        // Instancia átomos nos vértices
        foreach (Vector3 pos in vertexPositions)
        {
            Instantiate(atomPrefab, pos, Quaternion.identity);
            atomPositions.Add(pos);
        }

        // Instancia átomos nos centros das faces
        foreach (Vector3 pos in faceCenters)
        {
            Instantiate(atomPrefab, pos, Quaternion.identity);
            faceCenterPositions.Add(pos);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        if (atomPositions.Count == 8 && faceCenterPositions.Count == 6)
        {
            DrawCubeEdges();

            foreach (var faceCenter in faceCenterPositions)
            {
                foreach (var vertex in atomPositions)
                {
                    Gizmos.DrawLine(faceCenter, vertex);
                }
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
