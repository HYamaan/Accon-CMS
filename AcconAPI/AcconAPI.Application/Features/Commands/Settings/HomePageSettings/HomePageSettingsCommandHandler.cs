using AcconAPI.Application.Features.Commands.Partner.UpdatePartner;
using AcconAPI.Application.Repository;
using AcconAPI.Application.Services.Helpers;
using AcconAPI.Application.Services.Storage;
using AcconAPI.Domain.Common;
using AcconAPI.Domain.Entities.File;
using AcconAPI.Domain.Entities.Settings;
using AcconAPI.Domain.Enum;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Application.Features.Commands.Settings.HomePageSettings;

public class HomePageSettingsCommandHandler : IRequestHandler<HomePageSettingsCommandRequest, ResponseModel<HomePageSettingsCommandResponse>>
{
    private readonly IGenericRepository<Domain.Entities.Settings.HomePageSettings> _homePageSettingsRepository;
    private readonly IGenericRepository<CounterBackgroundPhoto> _counterBackgroundPhotoRepository;
    private readonly IFileCheckHelper _fileCheckHelper;
    private readonly IStorageService _storageService;

    public HomePageSettingsCommandHandler(IGenericRepository<Domain.Entities.Settings.HomePageSettings> homePageSettingsRepository, IStorageService storageService, IFileCheckHelper fileCheckHelper, IGenericRepository<CounterBackgroundPhoto> counterBackgroundPhotoRepository)
    {
        _homePageSettingsRepository = homePageSettingsRepository;
        _storageService = storageService;
        _fileCheckHelper = fileCheckHelper;
        _counterBackgroundPhotoRepository = counterBackgroundPhotoRepository;
    }

    public async Task<ResponseModel<HomePageSettingsCommandResponse>> Handle(HomePageSettingsCommandRequest request, CancellationToken cancellationToken)
    {

        if (HomePageEnum.WhyChooseUs == request.SettingId)
            return await WhyChooseUsSetting(request, cancellationToken);
        else if (HomePageEnum.Service == request.SettingId)
            return await ServiceSetting(request, cancellationToken);
        else if (HomePageEnum.Portfolio == request.SettingId)
            return await PortfolioSetting(request, cancellationToken);
        else if (HomePageEnum.Team == request.SettingId)
            return await TeamSetting(request, cancellationToken);
        else if (HomePageEnum.Testimonial == request.SettingId)
            return await TestimonialSetting(request, cancellationToken);
        else if (HomePageEnum.Faq == request.SettingId)
            return await FaqSetting(request, cancellationToken);
        else if (HomePageEnum.Gallery == request.SettingId)
            return await GallerySetting(request, cancellationToken);
        else if (HomePageEnum.RecentPost == request.SettingId)
            return await RecentPostSetting(request, cancellationToken);
        else if (HomePageEnum.Partner == request.SettingId)
            return await PartnerSetting(request, cancellationToken);
        else if (HomePageEnum.CounterBackgroundPhoto == request.SettingId)
            return await CounterBackgroundPhotoSetting(request, cancellationToken);
        else if (HomePageEnum.CounterSettings == request.SettingId)
            return await CounterSettingsSetting(request, cancellationToken);
        //else if (HomePageEnum.TotalRecentPosts == request.SettingId)
        //    return await TotalRecentPostsSetting(request, cancellationToken);
        else
            return ResponseModel<HomePageSettingsCommandResponse>.Fail("Setting not found");
    }


    public async Task<ResponseModel<HomePageSettingsCommandResponse>> WhyChooseUsSetting(
        HomePageSettingsCommandRequest request, CancellationToken cancellationToken)
    {
        var homePageSettings = await _homePageSettingsRepository.GetWhere(x => x.SettingId == request.SettingId).FirstOrDefaultAsync();
        if (homePageSettings == null)
        {
            homePageSettings = new Domain.Entities.Settings.HomePageSettings
            {
                SettingId = request.SettingId,
                Title = request.Title,
                SubTitle = request.SubTitle,
                Status = request.Status
            };
            await _homePageSettingsRepository.AddAsync(homePageSettings);
        }
        else
        {
            homePageSettings.Title = request.Title;
            homePageSettings.SubTitle = request.SubTitle;
            homePageSettings.Status = request.Status;
            _homePageSettingsRepository.Update(homePageSettings);
        }
        await _homePageSettingsRepository.SaveAsync();

        return ResponseModel<HomePageSettingsCommandResponse>.Success("WhyChooseUs setting updated");
    }
    public async Task<ResponseModel<HomePageSettingsCommandResponse>> ServiceSetting(
        HomePageSettingsCommandRequest request, CancellationToken cancellationToken)
    {

        var homePageSettings = await _homePageSettingsRepository.GetWhere(x => x.SettingId == request.SettingId).FirstOrDefaultAsync();
        if (homePageSettings == null)
        {
            homePageSettings = new Domain.Entities.Settings.HomePageSettings
            {
                SettingId = request.SettingId,
                Title = request.Title,
                SubTitle = request.SubTitle,
                Status = request.Status
            };
            await _homePageSettingsRepository.AddAsync(homePageSettings);
        }
        else
        {
            homePageSettings.Title = request.Title;
            homePageSettings.SubTitle = request.SubTitle;
            homePageSettings.Status = request.Status;
            _homePageSettingsRepository.Update(homePageSettings);
        }

        await _homePageSettingsRepository.SaveAsync();

        return ResponseModel<HomePageSettingsCommandResponse>.Success("Service setting updated");
    }

    public async Task<ResponseModel<HomePageSettingsCommandResponse>> PortfolioSetting(
        HomePageSettingsCommandRequest request, CancellationToken cancellationToken)
    {
        var homePageSettings = await _homePageSettingsRepository.GetWhere(x => x.SettingId == request.SettingId).FirstOrDefaultAsync();
        if (homePageSettings == null)
        {
            homePageSettings = new Domain.Entities.Settings.HomePageSettings
            {
                SettingId = request.SettingId,
                Title = request.Title,
                SubTitle = request.SubTitle,
                Status = request.Status
            };
            await _homePageSettingsRepository.AddAsync(homePageSettings);
        }
        else
        {
            homePageSettings.Title = request.Title;
            homePageSettings.SubTitle = request.SubTitle;
            homePageSettings.Status = request.Status;
            _homePageSettingsRepository.Update(homePageSettings);
        }
        await _homePageSettingsRepository.SaveAsync();

        return ResponseModel<HomePageSettingsCommandResponse>.Success("Portfolio setting updated");
    }

    public async Task<ResponseModel<HomePageSettingsCommandResponse>> TeamSetting(
        HomePageSettingsCommandRequest request, CancellationToken cancellationToken)
    {
        var homePageSettings = await _homePageSettingsRepository.GetWhere(x => x.SettingId == request.SettingId).FirstOrDefaultAsync();
        if (homePageSettings == null)
        {
            homePageSettings = new Domain.Entities.Settings.HomePageSettings
            {
                SettingId = request.SettingId,
                Title = request.Title,
                SubTitle = request.SubTitle,
                Status = request.Status
            };
            await _homePageSettingsRepository.AddAsync(homePageSettings);
        }
        else
        {
            homePageSettings.Title = request.Title;
            homePageSettings.SubTitle = request.SubTitle;
            homePageSettings.Status = request.Status;
            _homePageSettingsRepository.Update(homePageSettings);
        }
        await _homePageSettingsRepository.SaveAsync();

        return ResponseModel<HomePageSettingsCommandResponse>.Success("Team setting updated");
    }

    public async Task<ResponseModel<HomePageSettingsCommandResponse>> TestimonialSetting(
        HomePageSettingsCommandRequest request, CancellationToken cancellationToken)
    {
        var homePageSettings = await _homePageSettingsRepository.GetWhere(x => x.SettingId == request.SettingId).FirstOrDefaultAsync();
        if (homePageSettings == null)
        {
            homePageSettings = new Domain.Entities.Settings.HomePageSettings
            {
                SettingId = request.SettingId,
                Title = request.Title,
                SubTitle = request.SubTitle,
                Status = request.Status
            };
            await _homePageSettingsRepository.AddAsync(homePageSettings);
        }
        else
        {
            homePageSettings.Title = request.Title;
            homePageSettings.SubTitle = request.SubTitle;
            homePageSettings.Status = request.Status;
            _homePageSettingsRepository.Update(homePageSettings);
        }
        await _homePageSettingsRepository.SaveAsync();

        return ResponseModel<HomePageSettingsCommandResponse>.Success("Testimonial setting updated");
    }

    public async Task<ResponseModel<HomePageSettingsCommandResponse>> FaqSetting(
        HomePageSettingsCommandRequest request, CancellationToken cancellationToken)
    {
        var homePageSettings = await _homePageSettingsRepository.GetWhere(x => x.SettingId == request.SettingId).FirstOrDefaultAsync();
        if (homePageSettings == null)
        {
            homePageSettings = new Domain.Entities.Settings.HomePageSettings
            {
                SettingId = request.SettingId,
                Title = request.Title,
                SubTitle = request.SubTitle,
                Status = request.Status
            };
            await _homePageSettingsRepository.AddAsync(homePageSettings);
        }
        else
        {
            homePageSettings.Title = request.Title;
            homePageSettings.SubTitle = request.SubTitle;
            homePageSettings.Status = request.Status;
            _homePageSettingsRepository.Update(homePageSettings);
        }
        await _homePageSettingsRepository.SaveAsync();

        return ResponseModel<HomePageSettingsCommandResponse>.Success("Faq setting updated");
    }

    public async Task<ResponseModel<HomePageSettingsCommandResponse>> GallerySetting(
        HomePageSettingsCommandRequest request, CancellationToken cancellationToken)
    {
        var homePageSettings = await _homePageSettingsRepository.GetWhere(x => x.SettingId == request.SettingId).FirstOrDefaultAsync();
        if (homePageSettings == null)
        {
            homePageSettings = new Domain.Entities.Settings.HomePageSettings
            {
                SettingId = request.SettingId,
                Title = request.Title,
                SubTitle = request.SubTitle,
                Status = request.Status
            };
            await _homePageSettingsRepository.AddAsync(homePageSettings);
        }
        else
        {
            homePageSettings.Title = request.Title;
            homePageSettings.SubTitle = request.SubTitle;
            homePageSettings.Status = request.Status;
            _homePageSettingsRepository.Update(homePageSettings);
        }
        await _homePageSettingsRepository.SaveAsync();

        return ResponseModel<HomePageSettingsCommandResponse>.Success("Gallery setting updated");
    }

    public async Task<ResponseModel<HomePageSettingsCommandResponse>> RecentPostSetting(
        HomePageSettingsCommandRequest request, CancellationToken cancellationToken)
    {

        var homePageSettings = await _homePageSettingsRepository.GetWhere(x => x.SettingId == request.SettingId).FirstOrDefaultAsync();
        if (homePageSettings == null)
        {
            homePageSettings = new Domain.Entities.Settings.HomePageSettings
            {
                SettingId = request.SettingId,
                Title = request.Title,
                SubTitle = request.SubTitle,
                Status = request.Status,
                TotalRecentPosts = request.TotalRecentPosts
            };
            await _homePageSettingsRepository.AddAsync(homePageSettings);
        }
        else
        {
            homePageSettings.Title = request.Title;
            homePageSettings.SubTitle = request.SubTitle;
            homePageSettings.Status = request.Status;
            homePageSettings.TotalRecentPosts = request.TotalRecentPosts;
            _homePageSettingsRepository.Update(homePageSettings);
        }
        await _homePageSettingsRepository.SaveAsync();

        return ResponseModel<HomePageSettingsCommandResponse>.Success("RecentPost setting updated");
    }

    public async Task<ResponseModel<HomePageSettingsCommandResponse>> PartnerSetting(
        HomePageSettingsCommandRequest request, CancellationToken cancellationToken)
    {
        var homePageSettings = await _homePageSettingsRepository.GetWhere(x => x.SettingId == request.SettingId).FirstOrDefaultAsync();
        if (homePageSettings == null)
        {
            homePageSettings = new Domain.Entities.Settings.HomePageSettings
            {
                SettingId = request.SettingId,
                Title = request.Title,
                SubTitle = request.SubTitle,
                Status = request.Status
            };
            await _homePageSettingsRepository.AddAsync(homePageSettings);
        }
        else
        {
            homePageSettings.Title = request.Title;
            homePageSettings.SubTitle = request.SubTitle;
            homePageSettings.Status = request.Status;
            _homePageSettingsRepository.Update(homePageSettings);
        }
        await _homePageSettingsRepository.SaveAsync();


        return ResponseModel<HomePageSettingsCommandResponse>.Success("Partner setting updated");
    }

    public async Task<ResponseModel<HomePageSettingsCommandResponse>> CounterBackgroundPhotoSetting(
        HomePageSettingsCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _fileCheckHelper.CheckImageFormat(request.CounterBackgroundPhoto))
                return ResponseModel<HomePageSettingsCommandResponse>.Fail("Photo format is not valid");


        
            var counterBackgroundPhoto = await _storageService.UploadAsync("files", request.CounterBackgroundPhoto);
            var counterBackgroundPhotoEntity = new CounterBackgroundPhoto()
            {
                Path = counterBackgroundPhoto.pathOrContainerName,
                FileName = counterBackgroundPhoto.fileName,
                Storage = _storageService.StorageName,
            };

            await _counterBackgroundPhotoRepository.AddAsync(counterBackgroundPhotoEntity);
            await _counterBackgroundPhotoRepository.SaveAsync();
            await _counterBackgroundPhotoRepository.CommitTransactionAsync();


            var homePageSettings = await _homePageSettingsRepository.GetWhere(x => x.SettingId == request.SettingId).FirstOrDefaultAsync();
            if (homePageSettings == null)
            {
                homePageSettings = new Domain.Entities.Settings.HomePageSettings()
                {
                    SettingId = request.SettingId,
                    Status = true,
                    CounterBackgroundPhoto = counterBackgroundPhotoEntity

                };
                await _homePageSettingsRepository.AddAsync(homePageSettings);
            }
            else
            {
                homePageSettings.CounterBackgroundPhoto = counterBackgroundPhotoEntity;
                _homePageSettingsRepository.Update(homePageSettings);
            }
            await _homePageSettingsRepository.SaveAsync();

            return ResponseModel<HomePageSettingsCommandResponse>.Success(
                new HomePageSettingsCommandResponse()
                {
                    Photo = counterBackgroundPhotoEntity.Path
                }
            );
        }
        catch (Exception e)
        {
            await _counterBackgroundPhotoRepository.RollbackTransactionAsync();
            return ResponseModel<HomePageSettingsCommandResponse>.Fail(e.Message);
        }
    }

    public async Task<ResponseModel<HomePageSettingsCommandResponse>> CounterSettingsSetting(
        HomePageSettingsCommandRequest request, CancellationToken cancellationToken)
    {
        var homePageSettings = await _homePageSettingsRepository.GetWhere(x => x.SettingId == request.SettingId).FirstOrDefaultAsync();
        if (homePageSettings == null)
        {
            homePageSettings = new Domain.Entities.Settings.HomePageSettings
            {
                SettingId = request.SettingId,
                Status = request.Status,
                Counter1Text = request.Counter1Text,
                Counter1Value = request.Counter1Value,
                Counter2Text = request.Counter2Text,
                Counter2Value = request.Counter2Value,
                Counter3Text = request.Counter3Text,
                Counter3Value = request.Counter3Value,
                Counter4Text = request.Counter4Text,
                Counter4Value = request.Counter4Value
            };
            await _homePageSettingsRepository.AddAsync(homePageSettings);
        }
        else
        {
            homePageSettings.Status = request.Status;
            homePageSettings.Counter1Text = request.Counter1Text;
            homePageSettings.Counter1Value = request.Counter1Value;
            homePageSettings.Counter2Text = request.Counter2Text;
            homePageSettings.Counter2Value = request.Counter2Value;
            homePageSettings.Counter3Text = request.Counter3Text;
            homePageSettings.Counter3Value = request.Counter3Value;
            homePageSettings.Counter4Text = request.Counter4Text;
            homePageSettings.Counter4Value = request.Counter4Value;
            _homePageSettingsRepository.Update(homePageSettings);
        }
        await _homePageSettingsRepository.SaveAsync();

        return ResponseModel<HomePageSettingsCommandResponse>.Success("CounterSettings setting updated");
    }

    //public async Task<ResponseModel<HomePageSettingsCommandResponse>> TotalRecentPostsSetting(
    //    HomePageSettingsCommandRequest request, CancellationToken cancellationToken)
    //{
    //    var homePageSettings = await _homePageSettingsRepository.GetWhere(x => x.SettingId == request.SettingId).FirstOrDefaultAsync();

    //    if (homePageSettings == null)
    //    {
    //        homePageSettings = new Domain.Entities.Settings.HomePageSettings
    //        {
    //            SettingId = request.SettingId,
    //            Status = true,
    //            TotalRecentPosts = request.TotalRecentPosts
    //        };
    //        await _homePageSettingsRepository.AddAsync(homePageSettings);
    //    }
    //    else
    //    {
    //        homePageSettings.TotalRecentPosts = request.TotalRecentPosts;
    //        _homePageSettingsRepository.Update(homePageSettings);
    //    }
    //    await _homePageSettingsRepository.SaveAsync();

    //    return ResponseModel<HomePageSettingsCommandResponse>.Success("TotalRecentPosts setting updated");
    //}

}