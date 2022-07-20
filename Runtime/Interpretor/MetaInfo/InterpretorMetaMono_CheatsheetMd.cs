using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpretorMetaMono_CheatsheetMd : AbstractInterpretorMetaMono
{
        
    [TextArea(0,10)]
    public string m_localCheatsheetInMarkDown;
    public string m_urlRemoteUpdatedCheatsheet;

    public override void GetDefaultMarkdownSection(out string markdownText)
    {
        markdownText = "**Cheatsheet:**  " + "\n";
        markdownText += "_Update version:_" + m_urlRemoteUpdatedCheatsheet + "  \n";
        markdownText += m_localCheatsheetInMarkDown + "  \n";
    }

}
