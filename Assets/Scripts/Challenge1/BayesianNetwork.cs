using UnityEngine;
using UnityEngine.AI;

public class BayesianDecisionMaker{

    public float GetRevealProbability(bool playerNear, bool playerAiming, bool othersAttacking){
        
        if (!playerNear && !playerAiming && !othersAttacking){
            return 0.1f;
        }
        if (playerNear && !playerAiming && !othersAttacking){
            return 0.3f;
        }
        if (playerNear && playerAiming && !othersAttacking){ 
            return 0.7f;
        }
        if (playerNear && playerAiming && othersAttacking){
            return 0.95f;
        }
        if (!playerNear && playerAiming && othersAttacking){ 
            return 0.6f;
        }
        return 0.2f;
    }

    public bool ShouldReveal(bool playerNear, bool playerAiming, bool othersAttacking)
    {
        float probability = GetRevealProbability(playerNear, playerAiming, othersAttacking);
        return Random.value < probability;
    }

    public bool ShouldAttack(bool playerNear, bool playerAiming, bool othersAttacking)
    {
        float probability = GetRevealProbability(playerNear, playerAiming, othersAttacking);
        return Random.value >= probability;
    }
}
