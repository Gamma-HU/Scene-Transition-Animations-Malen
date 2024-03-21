using UnityEngine;

// スクリプタブルオブジェクトの例
[CreateAssetMenu(fileName = "NewSettings", menuName = "Settings")]
public class Coordinates : ScriptableObject {
    public SceneTransition.SceneTransitionObject[] sceneTransitionObjects;
}