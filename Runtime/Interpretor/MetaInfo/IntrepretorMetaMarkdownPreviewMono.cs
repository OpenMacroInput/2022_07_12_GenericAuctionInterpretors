using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class IntrepretorMetaMarkdownPreviewMono : MonoBehaviour
{

    [TextArea(0,10)]
    public string m_markdownText;

    [ContextMenu("Refresh")]
    public void Refresh() {
        IntrepretorMetaMarkdownUtility.GetMarkdownOfMetaMono(this.gameObject, out m_markdownText);
    }
}
public class IntrepretorMetaMarkdownUtility {
    public static void GetMarkdownOfMetaMono(in GameObject target, out string markdown) {

        AbstractInterpretorMetaMono[] metaInfo =  target.GetComponentsInChildren<AbstractInterpretorMetaMono>(target);

        StringBuilder sb = new StringBuilder();
        foreach (var item in metaInfo.OrderBy(k => k.m_markDownPriority))
        {
            if (item != null) 
                sb.AppendLine(item.GetAsMarkdownSection());
        }
        markdown = sb.ToString();
    }
}