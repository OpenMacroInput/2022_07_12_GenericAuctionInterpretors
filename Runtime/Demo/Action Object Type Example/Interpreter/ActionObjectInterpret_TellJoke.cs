using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class ActionObjectInterpret_TellJoke : AbstractGenericIntepreterMono<IAbstractObjectCommandToInterpret>
    {
        public override bool CanInterpreterUnderstand(in IAbstractObjectCommandToInterpret value)
        {
            value.GetTypeOfClass(out System.Type t);
            if (t == typeof(PushObjectAsCommandToInterpreterDemo.JokeInfo))
            {
                return true;
            }
            return false;
        }
        public override void TryTranslate(out bool succedToTranslate, in IAbstractObjectCommandToInterpret value)
        {
            value.GetTypeOfClass(out System.Type t);
            if (t == typeof(PushObjectAsCommandToInterpreterDemo.JokeInfo))
            {
                PushObjectAsCommandToInterpreterDemo.JokeInfo l = value.GetCastOfTheObjectAs<PushObjectAsCommandToInterpreterDemo.JokeInfo>();
                Debug.Log("JOKE| "+l.m_jokeMessage);
                succedToTranslate = true;
            }
            else succedToTranslate = false;
        }
    }
