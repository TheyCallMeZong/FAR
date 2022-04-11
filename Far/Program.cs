using Far;

View view = View.GetInstance();
view.SetWindow();
view.ViewDesign();
view.ShowFiles(new Panel("C:\\", FilePanel.Left));
view.ShowFiles(new Panel("C:\\", FilePanel.Right));
Window window = new Window();
window.Run();