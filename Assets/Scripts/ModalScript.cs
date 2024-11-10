using UnityEngine;

public class ModalScript : MonoBehaviour
{
    [SerializeField] private GameObject content;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = !content.activeInHierarchy ? 0.0f : 1.0f;
            content.SetActive(!content.activeInHierarchy);
        }
    }
}
