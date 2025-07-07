using strange.extensions.context.impl;

public class MainRoot : ContextView
{
    void Awake()
    {
        context = new MainMenuContext(this);
    }
}