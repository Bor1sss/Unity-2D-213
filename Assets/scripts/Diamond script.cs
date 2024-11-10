using System;
using UnityEditor;
using UnityEngine;

public class Diamondscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private Transform arrow;
    
    private Rigidbody2D rb2d;
    private Vector2 startDragPosition;
    private Vector2 releasePosition;
    private bool isDragging = false;
    public static Vector2 currentForce;
    [SerializeField]
    private float minForce = 100f;
    [SerializeField] private float maxForce = 400f;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        if (Input. GetKeyDown(KeyCode.Space))
        {
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            float forceAmplitude = minForce +
                                   (maxForce - minForce) * ForceIndicatorScript.forceFactor;
            rb2d.AddForce(arrow.right*forceAmplitude);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            startDragPosition = Input.mousePosition;
            isDragging = true;

        }

        if (Input.GetMouseButtonDown(0))
        {
            releasePosition = Input.mousePosition;
            
        }

    if (Input.GetKeyUp(KeyCode.Mouse0) && isDragging)
        {
            releasePosition = Input.mousePosition;
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            Vector2 force = (startDragPosition - releasePosition) * 2; 
            currentForce= NormoliseForce(force);
            rb2d.AddForce(currentForce);
            isDragging = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
          // rb2d.AddTorque(-100);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            rb2d.angularVelocity = 0;
            rb2d.linearVelocity = Vector2.zero;
        }
        
        if (isDragging)
        {
            Vector2 currentMousePosition = (Input.mousePosition);
            Vector2 force = (startDragPosition - currentMousePosition) * 2; 
            currentForce= NormoliseForce(force);
        }
    }

    Vector2 NormoliseForce(Vector2 force)
    {
        Vector2 newForce=force;
        newForce.x = newForce.x > maxForce ? maxForce : newForce.x;
        newForce.y = newForce.y > maxForce ? maxForce : newForce.y;
        /*newForce.x = newForce.x < 0 ? 0 : newForce.x;
        newForce.y = newForce.y < 0 ? 0 : newForce.y;*/
        return newForce;
    }
}
