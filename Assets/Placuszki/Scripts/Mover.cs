using UnityEngine;

public class Mover : MonoBehaviour{

[Range(0.01f, 10)]public float speed = 1;

void Update(){
transform.Translate(speed * Time.deltaTime, 0,0);

}
}