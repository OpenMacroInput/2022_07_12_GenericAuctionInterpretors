using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpretorMetaMono_WhatIsUseToClaim : AbstractInterpretorMetaMono
{

    [TextArea(0, 10)]
    public string m_whatAllowsToClaimDescription = "It start by `==`  \n";

    public override void GetDefaultMarkdownSection(out string markdownText)
    {
        markdownText = "Understand the command if ...**  \n";
        markdownText += m_whatAllowsToClaimDescription;
    }
}
