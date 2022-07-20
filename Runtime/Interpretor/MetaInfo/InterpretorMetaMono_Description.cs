using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpretorMetaMono_Description : AbstractInterpretorMetaMono
{
    [TextArea(0,5)]
    public string m_whatDoesTheInterpretor;

   
    public override void GetDefaultMarkdownSection(out string markdownText)
    {
        markdownText = "This Interpretor will...  \n";
        markdownText += m_whatDoesTheInterpretor+ "  \n";
    }
   
}
