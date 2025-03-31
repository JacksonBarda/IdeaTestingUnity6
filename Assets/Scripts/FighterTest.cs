using UnityEngine;
using TMPro;

public class FighterTest : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI attackTextUI;
    [SerializeField] private TextMeshProUGUI defenseTextUI;
    [SerializeField] private Animator animator;
    [SerializeField]
    public int AttackPower = 10;
    [SerializeField]
    public int DefensePower = 10;
    public bool IsAnimationComplete { get; private set; } = true; 

    private void Start()
    {
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        DefensePower -= damage;
        if (DefensePower < 0) DefensePower = 0;
        UpdateUI();
    }

    public void TriggerAttackAnimation()
    {
        if(IsAnimationComplete){
            if (animator != null)
            {
                IsAnimationComplete = false; // Set the flag to true when the animation is triggered
                animator.SetTrigger("Attack");
            }    
        }

    }

    // This method will be called by the animation event
    public void OnAttackAnimationComplete()
    {
        //Debug.Log("Anim Completed");
        IsAnimationComplete = true;
    }

    private void UpdateUI()
    {
        attackTextUI.text = AttackPower.ToString();
        if(DefensePower <= 0){
            DefensePower = 0; // Ensure DefensePower is not negative
            //GameManager.Instance.ChangeState(GameManager.GameState.Prep); // Change state to Prep if dead
        }         
        defenseTextUI.text = DefensePower > 0 ? DefensePower.ToString() : "Dead";
    }
}
