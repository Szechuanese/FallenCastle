using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone_skill : Skill
{
    [Header("clone info")]
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private float cloneDuration;

    public void CreateClone(Transform _clonePosition)
    {
        GameObject newClone = Instantiate(clonePrefab);

        newClone.GetComponent<Clone_skill_controller>().SetupClone(_clonePosition,cloneDuration);

    }
}
