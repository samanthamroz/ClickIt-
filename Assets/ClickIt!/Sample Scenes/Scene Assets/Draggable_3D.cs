using System.Collections;
using ClickIt;
using UnityEngine;

public class Draggable_3D : MonoBehaviour
{
    private Vector3 startPos;
    void Start() {
        startPos = transform.parent.position;
    }

    public void StartDragging() {
        StartCoroutine(Drag());
    }

    private IEnumerator Drag() {
        while (true) {
            float z = transform.position.z;
            Vector3 mousePos = ClickItCore.Instance.GetMousePosition();
            mousePos.z = Camera.main.WorldToScreenPoint(transform.parent.position).z; // Distance from camera
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = z;
            transform.parent.position = worldPos;
            yield return null;
        }
    }

    public void SnapBack() {
        StopAllCoroutines();
        transform.parent.position = startPos;
    }
}