using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubicSimple : MonoBehaviour
{
    public GameObject atomPrefab;  // Prefab do átomo (esfera)
    public float cubeSize = 1.0f;  // Tamanho do cubo
    public Material lineMaterial;  // Material para o LineRenderer (defina um no inspetor)
    private List<Vector3> atomPositions = new List<Vector3>();

    void Start()
    {
        // Posições dos 8 vértices do cubo
        Vector3[] positions = {
            new Vector3(0, 0, 0),
            new Vector3(cubeSize, 0, 0),
            new Vector3(0, cubeSize, 0),
            new Vector3(0, 0, cubeSize),
            new Vector3(cubeSize, cubeSize, 0),
            new Vector3(0, cubeSize, cubeSize),
            new Vector3(cubeSize, 0, cubeSize),
            new Vector3(cubeSize, cubeSize, cubeSize)
        };

        // Instanciar átomos e armazenar suas posições
        foreach (Vector3 pos in positions)
        {
            Instantiate(atomPrefab, pos, Quaternion.identity);
            atomPositions.Add(pos); // Adiciona a posição à lista
        }

        // Desenha as linhas entre os átomos
        if (atomPositions.Count == 8)
        {
            DrawCubeEdges();
        }
    }

    void DrawCubeEdges()
    {
        // Define as conexões entre os vértices do cubo (arestas)
        ConnectAtoms(atomPositions[0], atomPositions[1]);
        ConnectAtoms(atomPositions[0], atomPositions[2]);
        ConnectAtoms(atomPositions[0], atomPositions[3]);
        ConnectAtoms(atomPositions[1], atomPositions[4]);
        ConnectAtoms(atomPositions[1], atomPositions[6]);
        ConnectAtoms(atomPositions[2], atomPositions[4]);
        ConnectAtoms(atomPositions[2], atomPositions[5]);
        ConnectAtoms(atomPositions[3], atomPositions[6]);
        ConnectAtoms(atomPositions[3], atomPositions[5]);

        // Linhas no topo
        ConnectAtoms(atomPositions[4], atomPositions[7]);
        ConnectAtoms(atomPositions[5], atomPositions[7]);
        ConnectAtoms(atomPositions[6], atomPositions[7]);
    }

    // Função para criar um LineRenderer entre dois átomos
    void ConnectAtoms(Vector3 start, Vector3 end)
    {
        // Cria um objeto vazio que irá conter o LineRenderer
        GameObject lineObject = new GameObject("Line");
        LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();

        // Define as propriedades do LineRenderer
        lineRenderer.material = lineMaterial;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, start);  // Define o ponto inicial da linha
        lineRenderer.SetPosition(1, end);    // Define o ponto final da linha
    }
}
