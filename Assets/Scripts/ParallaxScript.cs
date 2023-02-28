using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParallaxScript : MonoBehaviour
{
    //Vector2 Pos;
    Vector2 StartPos;
    [SerializeField] int MoveModifer;

    private void Start()
    {
        StartPos = transform.position;

    }

    private void Update()
    {
      Vector2 Pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float posX = Mathf.Lerp(transform.position.x, StartPos.x + (Pos.x * MoveModifer), 2f * Time.deltaTime);
        float posY = Mathf.Lerp(transform.position.y, StartPos.y + (Pos.y * MoveModifer), 2f * Time.deltaTime);

        transform.position = new Vector3(
           posX,
           posY,
           0
           );
    }
}
