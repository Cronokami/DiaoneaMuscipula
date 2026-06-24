using UnityEngine;

public class BasePlant : MonoBehaviour
{
    public GameObject Vaso;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vaso.transform.position;
    }
}
