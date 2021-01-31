using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="ScriptableObjects/GameData")]
public class GameData : ScriptableObject
{
    public List<BossData> bossDatas;
}
