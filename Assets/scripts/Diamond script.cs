using System;
using UnityEditor;
using UnityEngine;

public class Diamondscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody2D rb2d;
    private Vector2 startDragPosition;
    private Vector2 releasePosition;
    private bool isDragging = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        // Начало перетаскивания при нажатии левой кнопкой мыши
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            startDragPosition = Input.mousePosition;
            isDragging = true;
            
        }

        // Завершение перетаскивания и запуск объекта
        if (Input.GetKeyUp(KeyCode.Mouse0) && isDragging)
        {
            releasePosition = Input.mousePosition;
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            Vector2 force = (startDragPosition - releasePosition) * 2; 
            rb2d.AddForce(force);
            isDragging = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
           rb2d.AddTorque(-100);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            rb2d.angularVelocity = 0;
            rb2d.linearVelocity = Vector2.zero;
        }
        
        if (isDragging)
        {
            Vector2 currentMousePosition = (Input.mousePosition);
      
        }
    }
}
