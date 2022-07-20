using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpretorMetaMono_TextSection : AbstractInterpretorMetaMono
{
   
    [TextArea(0,10)]
    public string m_someTextInMarkdownForDocumentation;

    public override void GetDefaultMarkdownSection(out string markdownText)
    {
        markdownText = m_someTextInMarkdownForDocumentation;
    }
}
