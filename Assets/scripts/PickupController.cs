using UnityEngine;

public class PickupController : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    // When touching another object
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player"))
            Instantiate(Resources.Load("prefabs/Enemy"), GameObject.FindWithTag("Respawn").transform.position, Quaternion.identity);
    }
}
