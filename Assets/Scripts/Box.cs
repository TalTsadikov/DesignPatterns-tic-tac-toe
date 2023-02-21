using UnityEngine ;

public class Box : MonoBehaviour
{
   public int index ;
   public Mark mark ;
   public bool isMarked ;

   public SpriteRenderer spriteRenderer ;

   private void Awake () {
      spriteRenderer = GetComponent<SpriteRenderer> () ;

      index = transform.GetSiblingIndex () ;
      mark = Mark.None ;
      isMarked = false ;
   }
}
