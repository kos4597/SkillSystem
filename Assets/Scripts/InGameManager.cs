using UnityEngine;

public class InGameManager : MonoBehaviour
{
    [SerializeField]
    private Actor player = null;
    public Actor Player => player;

    [SerializeField]
    private Actor enemy = null;
    public Actor Enemy => enemy;


    public static InGameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

}
