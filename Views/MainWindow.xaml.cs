using System.IO;
using System.Windows;
using Microsoft.Win32;
using WpfApp1.Integration.Contracts;
using WpfApp1.Warehouse.Data.Contracts;

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IImportService _importService;
    private readonly IMarkingService _markingService;
    
    public MainWindow(IImportService importService, IMarkingService markingService)
    {
        _importService = importService;
        _markingService = markingService;
        InitializeComponent();
    }


    private void ShowFileDialog_OnClick(object sender, RoutedEventArgs e)
    {
        //ToDo - get from table
        var openFileDialog = new OpenFileDialog();
        if (openFileDialog.ShowDialog() != true) return;
        
        using var streamReader = new StreamReader(openFileDialog.OpenFile());
        var productCodes = new List<string>();
        while (streamReader.Peek() >= 0)
        {
            productCodes.Add(streamReader.ReadLine());
        }
        
        _importService.ImportProductFromFileByCode(productCodes);
    }

    private void GetMission_OnClick(object sender, RoutedEventArgs e)
    {
        var mission = _markingService.GetMission();
    }
}