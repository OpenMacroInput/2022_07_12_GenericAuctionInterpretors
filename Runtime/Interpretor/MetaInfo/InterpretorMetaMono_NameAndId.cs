using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpretorMetaMono_NameAndId : AbstractInterpretorMetaMono
{
    public I_IntepreterNameAndId m_interpretor;

    public override void GetDefaultMarkdownSection(out string markdownText)
    {
        m_interpretor = this.gameObject.GetComponent<I_IntepreterNameAndId>();
        if (m_interpretor != null)
        {
            markdownText = "Interpretor Name:" + m_interpretor.GetInterpreterDescriptionName() + "  \n";
            markdownText += "Interpretor Unique ID:" + m_interpretor.GetInterpreterUniqueID() + "  \n";
        }
        else {
            markdownText = "";
        }
    }
}
