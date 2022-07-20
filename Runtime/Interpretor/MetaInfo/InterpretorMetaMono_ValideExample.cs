using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpretorMetaMono_ValideExample : AbstractInterpretorMetaMono
{
    public string[] m_listOfValideExampleToHelpUserRememberYourTool;

    public override void GetDefaultMarkdownSection(out string markdownText)
    {
        markdownText = "**List of valide example**  ";
        for (int i = 0; i < m_listOfValideExampleToHelpUserRememberYourTool.Length; i++)
        {
            if (m_listOfValideExampleToHelpUserRememberYourTool[i]!=null)
                markdownText += "\n" + m_listOfValideExampleToHelpUserRememberYourTool[i] + "  ";
        }
    }

   
}
