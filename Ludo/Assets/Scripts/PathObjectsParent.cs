using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathObjectsParent : MonoBehaviour
{
   public PathPoints[] commonPathPoints;
   public PathPoints[] RedPathPoints;
   public PathPoints[] BluePathPoints;
   public PathPoints[] GreenPathPoints;
   public PathPoints[] YellowPathPoints;
   
   public PathPoints[] BasePathPoints;


   [Header("Scales and Positions Difference")]
   public float[] scales;
   public float[] positionsDifference;
   

}
