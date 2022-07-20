using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpretorMetaMono_ManualUrl : AbstractInterpretorMetaMono
{
    public string m_urlToManualToUnderstandTheInterpretor;
    public string[] m_additionalLinks;

    public override void GetDefaultMarkdownSection(out string markdownText)
    {
        markdownText = "Manual URL: " + m_urlToManualToUnderstandTheInterpretor+"  \n";
        markdownText+= "Additional Link:" + "  \n"; ;
        for (int i = 0; i < m_additionalLinks.Length; i++)
        {
            markdownText = "- "+ m_additionalLinks[i] + "  \n"; 
        }
    }
}
