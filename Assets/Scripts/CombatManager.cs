using UnityEngine;
using System.Collections;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance { get; private set; }
    private FighterTest friendlyFighter;
    private FighterTest enemyFighter;

    private void Start()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        // Find fighters by their tags
        friendlyFighter = GameObject.FindGameObjectWithTag("Friendly").GetComponent<FighterTest>();
        enemyFighter = GameObject.FindGameObjectWithTag("Enemy").GetComponent<FighterTest>();
        
    }

    private void Update()
    {
        // Check if the game state is Combat

    }

    public void StartCombat()
    {
        StartCoroutine(CombatSequence());
    }

    private IEnumerator CombatSequence()
    {
        while (friendlyFighter.DefensePower > 0 && enemyFighter.DefensePower > 0)
        {
            Debug.Log("Combat started!");
            // Trigger attack animations
            friendlyFighter.TriggerAttackAnimation();
            enemyFighter.TriggerAttackAnimation();

            // Wait for both animations to complete
            yield return new WaitUntil(() => friendlyFighter.IsAnimationComplete && enemyFighter.IsAnimationComplete);

            // Apply dame
            friendlyFighter.TakeDamage(enemyFighter.AttackPower);
            enemyFighter.TakeDamage(friendlyFighter.AttackPower);
            

        }
        if(friendlyFighter.DefensePower <= 0 || enemyFighter.DefensePower <= 0){
            if (friendlyFighter.DefensePower > 0)
            {
                Debug.Log("Friendly wins!");
            }
            else if (enemyFighter.DefensePower > 0)
            {
                Debug.Log("Enemy wins!");
            }else{
                Debug.Log("Both fighters are dead!");
            }
        }
        // Determine the winner


        // Transition to the next state
        GameManager.Instance.ChangeState(GameManager.GameState.Prep);
    }
}