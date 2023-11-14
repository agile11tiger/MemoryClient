﻿namespace MemoryClient.Pages;

[Route("Music/{StrFolderName}")]
public partial class Music
{
    protected override async Task OnInitializedAsync()
    {
        await InitializeAsync("api/Music");
    }

    public override async Task AddItemIfNotExistAsync()
    {
        if (!await UserChecker.CheckAdminRoleAsync() || !await UserChecker.CheckNullOrWhiteSpaceAsync(ItemAdderViewModel.Id))
            return;

        var musicModel = await DiscogsHelper.GetMusicModelAsync(ItemAdderViewModel.Id, PublicHttpClient);

        if (musicModel == default)
        {
            await UserChecker.ShowSomethingHappenedAsync();
            return;
        }

        musicModel.FolderName = FolderName;
        await AddItemIfNotExistAsync(musicModel);
    }
}
