namespace MAUIFileDownload;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnDownloadClicked(object sender, EventArgs e)
	{
        var httpClient = new HttpClient();
		var path = Environment.CurrentDirectory + "/download.pdf";
        var responseStream = await httpClient.GetStreamAsync("https://localhost:7040/download");
        using var fileStream = new FileStream(path, FileMode.Create);
        responseStream.CopyTo(fileStream);
        FileInfo info = new FileInfo(path);
        if (info.Exists) await DisplayAlert("Download", $"File Has been saved size: {info.Length} name: {info.FullName}", "OK");
    }
}


