using UnityEngine;
[CreateAssetMenu(fileName = "LevelScriptableObject", menuName = "ScriptableObjects/Level")]
public class LevelSO : ScriptableObject
{
    public int levelNum;
    public int wallHealth;
    public int maxWallHealth;
    public int enemyWallHealth;
    public int maxEnemyWallHealth;
    public int zombieHealth;
    public int maxZombieHealth;
    public int zombieScale;
    public int zombieAmount;
    public int coinEarned;
    public int zombieDamage;
}
