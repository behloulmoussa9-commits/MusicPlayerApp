using Plugin.Maui.Audio;

namespace MusicPlayerApp;

public partial class MainPage : ContentPage
{
    private IAudioPlayer? _audioPlayer;
    private readonly IAudioManager _audioManager;

    public MainPage(IAudioManager audioManager)
    {
        InitializeComponent();
        _audioManager = audioManager;
    }

    private async void OnPickFileClicked(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "اختر ملف صوتي",
                FileTypes = FilePickerFileType.Audio
            });

            if (result != null)
            {
                FileNameLabel.Text = result.FileName;
                var stream = await result.OpenReadAsync();
                _audioPlayer = _audioManager.CreatePlayer(stream);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("خطأ", ex.Message, "حسناً");
        }
    }

    private void OnPlayClicked(object sender, EventArgs e) => _audioPlayer?.Play();
    private void OnPauseClicked(object sender, EventArgs e) => _audioPlayer?.Pause();
    private void OnStopClicked(object sender, EventArgs e) => _audioPlayer?.Stop();
}
