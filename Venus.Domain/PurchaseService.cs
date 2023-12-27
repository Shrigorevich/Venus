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

    public async Task<PurchaseViewDto> CreatePurchase(string userId, CreatePurchaseDto purchase)
    {
        var model = await _purchaseRepo.CreatePurchase(userId, purchase);
        return _mapper.Map<PurchaseModel, PurchaseViewDto>(model);
    }

    public async Task<PurchaseViewDto> UpdatePurchase(string userId, Guid purchaseId, PurchaseDto purchase)
    {
        var model = await _purchaseRepo.UpdatePurchase(userId, purchaseId, purchase);
        return _mapper.Map<PurchaseModel, PurchaseViewDto>(model);
    }

    public async Task<List<PurchaseViewDto>> GetPurchases(string userId)
    {
        var models = await _purchaseRepo.GetPurchases(userId);
        return _mapper.Map<List<PurchaseModel>, List<PurchaseViewDto>>(models);
    }

    public async Task DeletePurchase(string userId, Guid purchaseId)
    {
        await _purchaseRepo.DeletePurchase(userId, purchaseId);
    }

    public async Task UpdatePurchaseTags(Guid purchaseId, int[] tagIds)
    {
        await _purchaseRepo.UpdatePurchaseTags(purchaseId, tagIds);
    }
}