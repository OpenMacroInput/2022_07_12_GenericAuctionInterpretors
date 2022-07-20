using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

/// <summary>
/// In most of my application I need to create code for each action.
/// But I can't link them until I have done the code.
/// With this class, you just have to create a data container class and push it to the auction house. 
/// The interpreter will see if they understand the type or the data inside the classe and execute it.
/// If it don't you will have the auction house that warn you that no intrepreter understand yet the command as object.
/// </summary>
public interface IAbstractObjectCommandToInterpret 
{
    /// <summary>
    /// Help the interpret to not use refextion to know what class type it is.
    /// </summary>
    /// <param name="actionType"></param>
    public void GetTypeOfClass(out Type actionType);

    /// <summary>
    /// If you use existing object you won't be able to inherit of this interface. so you can inherit or have a link to object.
    /// </summary>
    /// <param name="actionType"></param>
    public void GetObjectRef(out object actionType);

    /// <summary>
    /// The unique id must represent a version of class for the user to be able to look for documentation, report bug...
    /// </summary>
    /// <param name="uniqueId"></param>
    public void GetActionTypeUniqueId(out string uniqueId);
    public C GetCastOfTheObjectAs<C>();
}


public abstract class AbstractObjectAsCommand : IAbstractObjectCommandToInterpret
{
    public void GetActionTypeUniqueId(out string uniqueId) {
        GetObjectRef(out object actionType);
        uniqueId = TypeDescriptor.GetClassName(actionType);
    }
    public C GetCastOfTheObjectAs<C>()
    {
            GetTypeOfClass(out Type t);
            GetObjectRef(out object target);
            return (C) target;
    }

    public abstract void GetObjectRef(out object actionType);

    public void GetTypeOfClass(out Type actionType)
    {
        GetObjectRef(out object target);
        actionType = target.GetType();
    }
}

public class IsAbstractObjectAsCommand : AbstractObjectAsCommand
{
    public override void GetObjectRef(out object actionType)=> actionType = this;
}
public class PointAtAbstractObjectAsCommand : AbstractObjectAsCommand
{

    public object m_target;

    public PointAtAbstractObjectAsCommand(object target)
    {
        m_target = target;
    }
    public PointAtAbstractObjectAsCommand()
    {
        m_target = null;
    }


    public override void GetObjectRef(out object actionType) => actionType = m_target;
}