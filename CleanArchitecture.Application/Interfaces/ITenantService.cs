using System;
using System.Threading.Tasks;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Application.ViewModels.Tenants;

namespace CleanArchitecture.Application.Interfaces;

public interface ITenantService
{
    public Task<Guid> CreateTenantAsync(CreateTenantViewModel tenant);
    public Task UpdateTenantAsync(UpdateTenantViewModel tenant);
    public Task DeleteTenantAsync(Guid tenantId);
    public Task<TenantViewModel?> GetTenantByIdAsync(Guid tenantId);
    public Task<PagedResult<TenantViewModel>> GetAllTenantsAsync(PageQuery query, string searchTerm = "");
}