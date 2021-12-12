using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skill")]
public class Skill : ScriptableObject
{
    public string skillName;
    public string description;

    public bool isUnLocked = false;

    public List<Skill> nextSkills = new List<Skill>();

    public Action unLockedNextSkills;
}
