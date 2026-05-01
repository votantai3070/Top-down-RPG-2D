using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI instance { get; private set; }

    public Player player { get; private set; }

    public UI_Ingame ingameUI { get; private set; }

    private void Awake()
    {
        instance = this;

        ingameUI = GetComponentInChildren<UI_Ingame>(true);
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }
}
