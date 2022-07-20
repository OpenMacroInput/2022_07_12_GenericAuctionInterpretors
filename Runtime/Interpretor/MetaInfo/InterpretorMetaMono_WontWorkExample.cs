using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpretorMetaMono_WontWorkExample : AbstractInterpretorMetaMono
{
    public string[] m_listOfNotValideThatWontWork;

    public override void GetDefaultMarkdownSection(out string markdownText)
    {
        markdownText = "**List of not valide example**  ";
        for (int i = 0; i < m_listOfNotValideThatWontWork.Length; i++)
        {
            if (m_listOfNotValideThatWontWork[i] != null)
                markdownText += "\n" + m_listOfNotValideThatWontWork[i] + "  "; 
        }
    }

}
