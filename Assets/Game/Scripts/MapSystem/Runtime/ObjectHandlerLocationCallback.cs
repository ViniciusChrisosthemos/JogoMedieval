using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using UnityEngine;

public class ObjectHandlerLocationCallback : AbstractLocationCallback
{
    [SerializeField] private List<ObjectParameter> m_objectParameters;

    public override void HandleEnterLocation(IGameContext gameContext)
    {
        var parameters = m_objectParameters.Where(op => op.WhenEnter).ToList();

        parameters.ForEach(parameter => parameter.Object.SetActive(parameter.ToActive));
    }

    public override void HandleExitLocation(IGameContext gameContext)
    {
        var parameters = m_objectParameters.Where(op => op.WhenExit).ToList();

        parameters.ForEach(parameter => parameter.Object.SetActive(parameter.ToActive));
    }

    [Serializable]
    internal class ObjectParameter
    {
        public GameObject Object;
        public bool ToActive;
        public bool WhenEnter;
        public bool WhenExit;
    }
}
