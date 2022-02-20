using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways, RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.grey;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    Waypoint waypoint;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
//        DisplayCoordinates();
    }

    void Update()
    {
/*        // Limit to edit mode only
        if(!Application.isPlaying) {
            DisplayCoordinates();
            UpdateObjectName();
            label.enabled = true;
        }

        SetCoordinatesLabelColor();
        ToggleLabels();
*/    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C)) {
            label.enabled = !label.IsActive();
        }
    }

/*    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = $"{coordinates.x:D2},{coordinates.y:D2}";
    }

    void UpdateObjectName()
    {
        //transform.parent.name = coordinates.ToString("D2");
    }
*/
    void SetCoordinatesLabelColor()
    {
        label.color = waypoint.IsPlaceable ? defaultColor : blockedColor;
    }
}
