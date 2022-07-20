using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpretorMetaMono_ReadMeMd : AbstractInterpretorMetaMono
{

    [TextArea(0, 10)]
    public string m_m_inEnLocalReadMeInMarkDown;
    public string m_urlRemoteUpdatedReadMe;
    public override void GetDefaultMarkdownSection(out string markdownText)
    {
        markdownText = "**Read Me:**" + "  \n";
        markdownText += "_Update version:_" + m_urlRemoteUpdatedReadMe + "  \n";
        markdownText += m_m_inEnLocalReadMeInMarkDown + "  \n"; 
    }

}
