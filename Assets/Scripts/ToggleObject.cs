using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    public GameObject objeto;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            objeto.SetActive(false);
        }
    }
}