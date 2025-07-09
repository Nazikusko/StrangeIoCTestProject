using strange.extensions.context.impl;

public class MainMenuRoot : ContextView
{
    void Awake()
    {
        context = new MainMenuContext(this);
    }
}