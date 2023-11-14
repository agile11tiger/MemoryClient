﻿using MemoryLib.Extensions;
using MemoryLib.Models.Review;
using MemoryClient.Enums;
using System.ComponentModel.DataAnnotations;
namespace MemoryClient.Components.Pages;

[Route("Anime/{StrFolderName}")]
public partial class Anime
{
    protected override async Task OnInitializedAsync()
    {
        SortingParameters.Add(SortingKeys.AniDbRating, SortingKeys.AniDbRating.GetAttribute<DisplayAttribute>().Name);
        SortingParameters.Add(SortingKeys.MyRating, SortingKeys.MyRating.GetAttribute<DisplayAttribute>().Name);
        FilterParameters.Add(FilterKeys.AniDbRating, FilterKeys.AniDbRating.GetAttribute<DisplayAttribute>().Name);
        FilterParameters.Add(FilterKeys.AniDbRatingMore, FilterKeys.AniDbRatingMore.GetAttribute<DisplayAttribute>().Name);
        FilterParameters.Add(FilterKeys.AniDbRatingLess, FilterKeys.AniDbRatingLess.GetAttribute<DisplayAttribute>().Name);
        FilterParameters.Add(FilterKeys.MyRating, FilterKeys.MyRating.GetAttribute<DisplayAttribute>().Name);
        FilterParameters.Add(FilterKeys.MyRatingMore, FilterKeys.MyRatingMore.GetAttribute<DisplayAttribute>().Name);
        FilterParameters.Add(FilterKeys.MyRatingLess, FilterKeys.MyRatingLess.GetAttribute<DisplayAttribute>().Name);

        await InitializeAsync("api/Anime");
    }

    public override async Task AddItemIfNotExistAsync()
    {
        if (!await UserChecker.CheckAdminRoleAsync() || !await UserChecker.CheckNullOrWhiteSpaceAsync(ItemAdderViewModel.Id))
            return;

        var animemodel = new AnimeModel()
        {
            Link = ItemAdderViewModel.Id,
            AniDbId = AniDbHelper.GetId(ItemAdderViewModel.Id),
            FolderName = FolderName,
        };
        await AddItemIfNotExistAsync(animemodel);
    }
}
