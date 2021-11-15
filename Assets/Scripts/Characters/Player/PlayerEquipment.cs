using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    #region Meshs
    [SerializeField]
    private Mesh[] beltMeshs;
    [SerializeField]
    private Mesh[] colthMeshs;
    [SerializeField]
    private Mesh[] crownMeshs;
    [SerializeField]
    private Mesh[] fadeMeshs;
    [SerializeField]
    private Mesh[] gloveMesh;
    [SerializeField]
    private Mesh[] hairMeshs;
    [SerializeField]
    private Mesh[] hatMeshs;
    [SerializeField]
    private Mesh[] HelmetMeshs;
    [SerializeField]
    private Mesh[] pauldronMeshs;
    [SerializeField]
    private Mesh[] shoeMeshs;
    #endregion Meshs

    #region SkinnedMeshRenderers
    [SerializeField]
    private SkinnedMeshRenderer beltRenderer;
    [SerializeField]
    private SkinnedMeshRenderer clothRenderer;
    [SerializeField]
    private SkinnedMeshRenderer crownRenderer;
    [SerializeField]
    private SkinnedMeshRenderer faceRenderer;
    [SerializeField]
    private SkinnedMeshRenderer gloveRenderer;
    [SerializeField]
    private SkinnedMeshRenderer hairRenderer;
    [SerializeField]
    private SkinnedMeshRenderer hatRenderer;
    [SerializeField]
    private SkinnedMeshRenderer helmetRenderer;
    [SerializeField]
    private SkinnedMeshRenderer pauldronRenderer;
    [SerializeField]
    private SkinnedMeshRenderer shoeRenderer;
    #endregion SkinnedMeshRenderers
}
