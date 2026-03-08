using UnityEngine;
using System.Collections.Generic;

public class CardHolder : MonoBehaviour
{
    public List<Card> cards = new List<Card>();



    private void Update()
    {
        UpdateCardPositions();
        UpdateCardRotations();
    }



    public void UpdateCardPositions()
    {

        List<Vector3> positions = new List<Vector3>();
        List<Vector3> positionsTemp = new List<Vector3>();

        for (int i = 0; i < cards.Count; i++) {

            Vector3 pos = Vector3.zero + (Vector3.right * (i-1) * 150);
            positions.Add(pos);
            positionsTemp.Add(Vector3.zero);


        }

        int midPoint = Mathf.CeilToInt(positions.Count / 2);

        positionsTemp[0] = positions[Mathf.CeilToInt(positions.Count / 2)];
        positionsTemp[1] = positions[midPoint + 1];
        positionsTemp[2] = positions[midPoint - 1];
        positionsTemp[3] = positions[midPoint + 2];
        positionsTemp[4] = positions[midPoint - 2];
       // positionsTemp[5] = positions[midPoint + 3];
       // positionsTemp[6] = positions[midPoint - 3];

        positions = positionsTemp;




        for (int i = 0; i < cards.Count; i++) {

            cards[i].transform.localPosition = positions[i];
        
        
        }
      



    }

    public void UpdateCardRotations()
    {

    }



}
