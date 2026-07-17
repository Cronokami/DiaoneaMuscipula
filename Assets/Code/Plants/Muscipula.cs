using UnityEngine;
using UnityEngine.InputSystem;


public class Muscipula : MonoBehaviour
{
    public GameObject PlantHead;
    public PlayerInput playerInput;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = PlantHead.transform.position.z;
        Vector3 lookDirection = mouseWorldPosition - PlantHead.transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        PlantHead.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void OnAttack()
    {
        Debug.Log("attacks");
    }
}
