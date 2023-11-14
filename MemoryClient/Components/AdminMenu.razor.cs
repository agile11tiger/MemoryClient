﻿using MemoryClient.Services;
using Microsoft.JSInterop;
namespace MemoryClient.Components;

public partial class AdminMenu
{
    [Inject] public UserChecker UserChecker { get; set; }
    [Inject] public ServerHttpClient ServerHttpClient { get; set; }

    public async Task UpdateDiscogsImageSourcesAsync()
    {
        if (await UserChecker.CheckAdminRoleAsync())
        {
            await UserChecker.JS.InvokeVoidAsync("alert", $"Обновление изображений запущено");
            await ServerHttpClient.PostAsync("api/Music/UpdateImageSources", null);
            await UserChecker.JS.InvokeVoidAsync("alert", $"Обновление изображений завершено");
        }
    }

    public async Task UpdateFilmsAsync()
    {
        if (await UserChecker.CheckAdminRoleAsync())
        {
            await UserChecker.JS.InvokeVoidAsync("alert", $"Обновление фильмов запущено");
            await ServerHttpClient.PostAsync("api/Films/UpdateItems", null);
            await UserChecker.JS.InvokeVoidAsync("alert", $"Обновление фильмов завершено");
        }
    }

    public async Task UpdateSerialsAsync()
    {
        if (await UserChecker.CheckAdminRoleAsync())
        {
            await UserChecker.JS.InvokeVoidAsync("alert", $"Обновление сериалов запущено");
            await ServerHttpClient.PostAsync("api/Serials/UpdateItems", null);
            await UserChecker.JS.InvokeVoidAsync("alert", $"Обновление сериалов завершено");
        }
    }

    public async Task UpdateGamesItemsAsync()
    {
        if (await UserChecker.CheckAdminRoleAsync())
        {
            await UserChecker.JS.InvokeVoidAsync("alert", $"Обновление игр запущено");
            await ServerHttpClient.PostAsync("api/Games/UpdateItems", null);
            await UserChecker.JS.InvokeVoidAsync("alert", $"Обновление игр завершено");
        }
    }
}
