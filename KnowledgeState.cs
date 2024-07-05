using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KnowledgeState 
{
    public float masteryPropability;
    public float learningRate;
    public float guessRate;
    public float slipRate;

    //constructor
    public KnowledgeState(float initialKnowledgeProbability)
    {
        masteryPropability = initialKnowledgeProbability;
    }

    public void UpdateMasteryProbability(bool isCorrect, float learningRate, float guessRate, float slipRate)
    {
        float oldMasteryProbability = masteryPropability;
        float newMasteryProbability;

        if(isCorrect)
        {
            newMasteryProbability = (oldMasteryProbability * (1 - slipRate)) / ((oldMasteryProbability * slipRate) + ((1- oldMasteryProbability) * guessRate));
        }
        else
        {
            newMasteryProbability = (oldMasteryProbability * slipRate) / ((oldMasteryProbability * slipRate) + (( 1 - oldMasteryProbability) * ( 1 - guessRate)));
        }
        masteryPropability = oldMasteryProbability + (newMasteryProbability - oldMasteryProbability) * learningRate;
    }
}
