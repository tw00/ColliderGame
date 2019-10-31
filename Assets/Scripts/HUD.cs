using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public PlayerController player;
    public Text scoreText;
    public Text boostText;

    void Start () {
        boostText.gameObject.SetActive(player.useBoost);
    }

    void Update()
    {
        scoreText.text = player.transform.position.z.ToString("0");
        boostText.text = player.boostReserve.ToString("0.0");

        if (player.boostActive) {
            boostText.color = Color.red;
        } else if (player.boostReserve >= player.boostAcivationThreshold) {
            boostText.color = Color.green;
        }
    }
}
