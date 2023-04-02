using BankSystem.InternetBank.Models.Requests;
using BankSystem.InternetBank.Repositories;
using BankSystem.InternetBank.Validations;

namespace InternetBank.Tests;

public class RegisterAccountValidatorTests
{
    private readonly FakeBankSystemDbContext _db;
    private readonly UserRepository _userRepository;

    public RegisterAccountValidatorTests()
    {
        _db = new FakeBankSystemDbContext();
        _userRepository = new UserRepository(_db);
    }
    [Test]
    public void Validate_ValidRequest_NoExceptionThrown()
    {
        // Arrange
        var validator = new RegisterAccountValidator(_userRepository);
        var request = new RegisterAccountRequest
        {
            Amount = 100,
            PersonalId = "1234567890"
        };

        // Act and Assert
        Assert.Throws<ArgumentException>(() => validator.Validate(request));
    }

}