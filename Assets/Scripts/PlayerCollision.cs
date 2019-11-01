using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerController controller;
    public GameObject explosionPrefab;

    void OnCollisionEnter(Collision other) {

      if ( other.collider.tag == "Obstacle" ) {

        Vector3 exPosition = transform.position;
        // Vector3 exPosition = other.transform.position;

        GameObject explosion  = Instantiate(explosionPrefab, exPosition, Quaternion.identity);
        // explosion.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

        GetComponent<AudioSource>().Play();

        GameObject fuse = transform.GetChild(0).gameObject;
        if ( fuse != null ) {
          Destroy(fuse);
        }

        controller.enabled = false;
        FindObjectOfType<GameManager>().EndGame();
      }
    }
}
