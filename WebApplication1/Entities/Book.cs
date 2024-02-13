using System;
using System.Collections.Generic;
using TenantAuthenticator.Entity;
using TenantAuthenticator.Interface;

namespace WebApplication1.Entities;

public partial class Book : BaseEntity, IMultiTenant
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid TenantId { get; set; }
}
