using strange.extensions.context.impl;

namespace HOR.Entry.Start
{
    public class StartContextView : ContextView
    {
        void Start() {
            DontDestroyOnLoad(gameObject);
            context = new EntryContext(this, true);
            context.Start();
            Destroy(gameObject);
        }
    }
}
