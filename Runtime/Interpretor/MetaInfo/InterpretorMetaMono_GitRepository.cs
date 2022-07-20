using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpretorMetaMono_GitRepository : AbstractInterpretorMetaMono
{
    public string m_whereToFindTheGitSourceCode= "https://github.com/Who?tab=repositories";

    public override void GetDefaultMarkdownSection(out string markdownText)
    {
        markdownText = "**Git source:**" + m_whereToFindTheGitSourceCode + "  \n";
    }


}
    