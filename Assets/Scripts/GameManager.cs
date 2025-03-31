using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public enum GameState
    {
        Prep,
        Store,
        Drawing,
        Combat
    }

    public GameState CurrentState { get; private set; }
    // Event to notify other scripts when the state changes
    public delegate void OnStateChange(GameState newState);
    public event OnStateChange StateChanged;
    void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManager instances
        }
    }

    void Start()
    {
        // Initialize the game state
        ChangeState(GameState.Prep);
    }

    void Update()
    {

    }
        public void ChangeToPrepState()
    {
        ChangeToState(GameState.Prep);
    }
    
    public void ChangeToStoreState()
    {
        ChangeToState(GameState.Store);
    }
    
    public void ChangeToDrawingState()
    {
        ChangeToState(GameState.Drawing);
    }
    
    public void ChangeToCombatState()
    {
        ChangeToState(GameState.Combat);
        CombatManager.Instance.StartCombat(); // Start combat when changing to Combat state
    }
    public void ChangeToState(GameState newState)
    {
        ChangeState(newState);
    }

    public void ChangeState(GameState newState)
    {
        if (CurrentState != newState)
        {
            CurrentState = newState;
            Debug.Log($"Game state changed to: {newState}");

            // Notify listeners about the state change
            StateChanged?.Invoke(newState);
        }
    }
}
