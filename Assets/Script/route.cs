using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class route : MonoBehaviour
{
   Transform[] childObjects;
   public List<Transform> childNodes = new List<Transform>();

   void OnDrawGizmos() 
   {
        Gizmos.color = Color.green;
        FillNodes();
        for (int i = 0; i < childNodes.Count; i++)
        {
            Vector3 currentPos = childNodes[i].position;
            if(i>0)
            {
                Vector3 prevPos = childNodes[i-1].position;
                Gizmos.DrawLine(prevPos,currentPos);
            }
        }
   }    

   void FillNodes()
   {
        childNodes.Clear();

        childObjects = GetComponentsInChildren<Transform>();

        foreach(Transform child in childObjects)
        {
            if(child != this.transform)
            {
                childNodes.Add(child);
            }
        }
   }

}
