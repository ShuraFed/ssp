using System;

namespace stonepaper
{
    class Winner
    {
        internal static string Show(string[] possiblemoves,int humanTurn, int computerTurn)
        {
            string w = "";
            if (humanTurn==computerTurn)
            {
                w = "Draw";
            }
            else if (Math.Abs(humanTurn-computerTurn)<=possiblemoves.Length/2)
            {
                w = humanTurn > computerTurn ? "Lose" : "Win";
            }
            else
            {
                w = humanTurn < computerTurn ? "Lose" : "Win";
            }
            return w;
        }
    }
}
