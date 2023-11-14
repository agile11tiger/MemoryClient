namespace MemoryClient.Components.Pages;

[Route("Games/{StrFolderName}")]
public partial class Games
{
    protected override async Task OnInitializedAsync()
    {
        await InitializeAsync("api/Games");
    }
}
