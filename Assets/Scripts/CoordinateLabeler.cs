using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways, RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor  = Color.white;
    [SerializeField] Color blockedColor  = Color.grey;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor     = new Color(1f, 0.5f, 0f); // Orange

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    GridManager gridManager;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        gridManager = FindObjectOfType<GridManager>();
        DisplayCoordinates();
    }

    void Update()
    {
        // Limit to edit mode only
        if(!Application.isPlaying) {
            DisplayCoordinates();
            UpdateObjectName();
            label.enabled = true;
        }

        SetCoordinatesLabelColor();
        ToggleLabels();
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C)) {
            label.enabled = !label.IsActive();
        }
    }

    void DisplayCoordinates()
    {
        if (gridManager == null) return;

        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize);
        label.text = $"{coordinates.x:D2},{coordinates.y:D2}";
    }

    void UpdateObjectName()
    {
        //transform.parent.name = coordinates.ToString("D2");
    }

    void SetCoordinatesLabelColor()
    {
        // No grid manager? bail
        if (gridManager == null) return;
        // Empty node? bail
        Node node = gridManager.GetNode(coordinates);
        if (node == null) return;

        // Set color based on condition
        if (!node.isWalkable) {
            label.color = blockedColor;
        } else if (node.isPath) {
            label.color = pathColor;
        } else if (node.isExplored) {
            label.color = exploredColor;
        } else {
            label.color = defaultColor;
        }
    }
}
