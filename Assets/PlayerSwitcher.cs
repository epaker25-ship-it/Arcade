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
        players[currentIndex].enabled = false;

        currentIndex = (currentIndex + 1) % players.Length;

        players[currentIndex].enabled = true;
    }

    public void OnSpecial(InputValue value)
    {
        if (value.isPressed)
        {
            players[currentIndex].GetComponent<CharacterSpecial>().UseSpecial();
        }
    }

}
