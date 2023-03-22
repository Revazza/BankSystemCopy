using Microsoft.AspNetCore.Identity;
using System;
using Newtonsoft.Json;

namespace BankSystem.Common.Db.Entities;

public class UserEntity : IdentityUser<Guid>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PersonalNumber { get; set; } = new Random().Next(100000000, 999999999).ToString();
    public DateTime BirthDate { get; set; } = DateTime.Now.AddYears(-10);
    public DateTime RegisteredAt { get; set; } = DateTime.Now;
    [JsonIgnore]
    public List<AccountEntity> Accounts { get; set; }

    public UserEntity()
    {
        Accounts = new List<AccountEntity>();
    }
}