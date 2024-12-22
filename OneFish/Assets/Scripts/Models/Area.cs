using UnityEngine;

//public enum AreaTag { Fishing, None }
//[CreateAssetMenu(fileName = "NewArea", menuName = "OneFish/Area")]
public class Area : MonoBehaviour
{
    CircleCollider2D areaCollider;
    void AreaColisao()
    {
        areaCollider = GetComponent<CircleCollider2D>();

    }
}
