using Microsoft.AspNetCore.Identity;

namespace CommonServices.Db.Entities;

public class OperatorEntity
{ 
    public Guid Id { get; set; }
    public string Name { get; set; }
}