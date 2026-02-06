using System.Collections;
using ClickIt;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Draggable_2D : MonoBehaviour
{
    private Vector3 startingPos;

    void Start() {
        startingPos = transform.position;
    }

    public void StartDragging() {
        StartCoroutine(Drag());
    }

    private IEnumerator Drag() {
        while (true) {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(ClickItCore.Instance.GetMousePosition());
            transform.position = worldPos;
            yield return null;
        }
    }

    public void SnapBack() {
        StopAllCoroutines();
        transform.position = startingPos;
    }
}