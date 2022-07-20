using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInterpretorMeta
{
    public string GetAsMarkdownSection();
    public void GetDefaultMarkdownSection(out string markdownText);
    public void GetPriorityInGeneratedMarkdown(out int priority_0Hight_9999Low);
}

public abstract class AbstractInterpretorMetaMono : MonoBehaviour, IInterpretorMeta
{
    public int m_markDownPriority;
    public string GetAsMarkdownSection() { GetDefaultMarkdownSection(out string t); return t; }
    public abstract void GetDefaultMarkdownSection(out string markdownText);
    public void GetPriorityInGeneratedMarkdown(out int priority_0Hight_9999Low) => priority_0Hight_9999Low = m_markDownPriority;
}
public abstract class AbstractInterpretorMeta : IInterpretorMeta
{
    public int m_markDownPriority;
    public string GetAsMarkdownSection() { GetDefaultMarkdownSection(out string t); return t; }
    public abstract void GetDefaultMarkdownSection(out string markdownText);
    public void GetPriorityInGeneratedMarkdown(out int priority_0Hight_9999Low) => priority_0Hight_9999Low = m_markDownPriority;
}
