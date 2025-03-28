using UnityEngine;
using TMPro; // Make sure to include this namespace for TextMeshPro

public class FighterTest : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI attackTextUI; // Reference to the TextMeshProUGUI component
    [SerializeField]
    private int attackPower = 10;
    [SerializeField]
    private TextMeshProUGUI defenseTextUI; // Reference to the TextMeshProUGUI component
    [SerializeField]
    private int defensePower = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackTextUI.text = attackPower.ToString();
        defenseTextUI.text = defensePower.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextTurn(){
        if(attackPower > 0)
        {
            //attackPower--;
            //attackTextUI.text = attackPower.ToString();
        }
        if(defensePower > 0){
            defensePower--;
            defenseTextUI.text = defensePower.ToString();
        }else{
            attackTextUI.text = "";
            defenseTextUI.text = "dead";
        }
    }
}
