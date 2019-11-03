using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
  public Transform parentTransform;
  public GameObject[] prefabsLevel;
  public GameObject[] prefabsEnemies;
  public GameObject prefabEndTrigger;
  public uint levelLength = 10;

  void Start()
  {
    foreach (Transform child in parentTransform)
    {
      Destroy(child.gameObject);
    }

    /* Transform[] ts = parentTransform.child<Transform>();
    foreach (Transform child in ts) {
      if (child != null && child.gameObject != null) {
        Debug.Log(child.gameObject);
        Debug.Log(child.gameObject);
      }
    } */

    for (uint n = 0; n < this.levelLength; n++)
    {
      Vector3 position = new Vector3(-3f, -1f, n * 30f);

      int index = Random.Range(0, prefabsLevel.Length);

      GameObject p = Instantiate(
          this.prefabsLevel[index],
          position,
          Quaternion.identity) as GameObject;

      p.transform.parent = this.parentTransform;
    }

    for (uint n = 0; n < 2 * prefabsLevel.Length; n++)
    {
      float x = Random.Range(-3f, 3f);
      float z = Random.Range(15f, 30f * this.levelLength);
      Vector3 position = new Vector3(x, +1f, z);
      int index = Random.Range(0, prefabsEnemies.Length);

      GameObject p = Instantiate(
                this.prefabsEnemies[index],
                position,
                Quaternion.identity) as GameObject;
      p.transform.parent = this.parentTransform;
    }


    Vector3 position2 = new Vector3(0f, 2f, this.levelLength * 30f);
    GameObject p2 = Instantiate(
              this.prefabEndTrigger,
              position2,
              Quaternion.identity) as GameObject;
    p2.transform.parent = this.parentTransform;
  }
}
