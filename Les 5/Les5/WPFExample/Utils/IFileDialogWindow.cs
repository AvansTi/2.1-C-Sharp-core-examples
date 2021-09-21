namespace WPFExample.Utils
{
    using System.Collections.Generic;
    public interface IFileDialogWindow
    {
        List<string> ExecuteFileDialog(object owner, string extFilter);
    }
}
