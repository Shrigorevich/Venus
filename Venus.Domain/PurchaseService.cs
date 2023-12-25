using AutoMapper;
using Venus.Database.Contracts;
using Venus.Database.Models;
using Venus.Dto.Accounting;

namespace Venus.Domain;

public class PurchaseService : IPurchaseService
{
    private readonly IMapper _mapper;
    private readonly IPurchaseRepo _purchaseRepo;

    public PurchaseService(IMapper mapper, IPurchaseRepo purchaseRepo)
    {
        _mapper = mapper;
        _purchaseRepo = purchaseRepo;
    }

    public async Task<PurchaseDto> CreatePurchase(string userId, CreatePurchaseDto purchase)
    {
        var model = await _purchaseRepo.CreatePurchase(userId, purchase);
        return _mapper.Map<PurchaseModel, PurchaseDto>(model);
    }

    public async Task<List<PurchaseDto>> GetPurchases(string userId)
    {
        var models = await _purchaseRepo.GetPurchases(userId);
        return _mapper.Map<List<PurchaseModel>, List<PurchaseDto>>(models);
    }

    public async Task AddPurchaseTag(Guid purchaseId, int tagId)
    {
        await _purchaseRepo.AddPurchaseTag(purchaseId, tagId);
    }
}