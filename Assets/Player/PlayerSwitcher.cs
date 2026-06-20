using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSwitcher : MonoBehaviour
{
    public PlayerInput[] players;
    private int currentIndex = 0;

    void Start()
    {
        //disable players
        for (int i = 0; i < players.Length; i++)
            players[i].enabled = (i == currentIndex);
    }

    public void OnSwitch(InputValue value)
    {
        if (value.isPressed)
        {
            SwitchPlayer();
        }
    }

    void SwitchPlayer()
    {
        players[currentIndex].GetComponent<FlashEffect>().Flash(Color.black);

        players[currentIndex].GetComponent<PlayerInput>().enabled = false;

        currentIndex = (currentIndex + 1) % players.Length;

        players[currentIndex].GetComponent<PlayerInput>().enabled = true;

        players[currentIndex].GetComponent<FlashEffect>().Flash(new Color(2f, 2f, 2f, 1f));

        Camera.main.GetComponent<CameraFollow>().target = players[currentIndex].transform;
    }


    public void OnSpecial(InputValue value)
    {
        if (value.isPressed)
        {
            players[currentIndex].GetComponent<CharacterSpecial>().UseSpecial();
        }
    }

}
