﻿namespace MemoryClient.Components.Pages;

[Route("Serials/{StrFolderName}")]
public partial class Serials
{
    protected override async Task OnInitializedAsync()
    {
        await InitializeAsync("api/Serials");
    }
}
