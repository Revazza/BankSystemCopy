using BankSystem.Common.Db.Entities;
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
    [SetUp]
    public void SetUp()
    {
        var user = new UserEntity()
        {
           PersonalNumber = "1234567891",
           FirstName = "Ana",
           LastName = "Mk"
        };
        _db.Users.Add(user);
        _db.SaveChanges();
    }
    [Test]
    public void Validate_ValidRequest_NoExceptionThrown()
    {
       
        var validator = new RegisterAccountValidator(_userRepository);
        var request = new RegisterAccountRequest
        {
            Amount = 100,
            PersonalId = "12345678917"
        };

    
        Assert.DoesNotThrow(() => validator.Validate(request));
    }
    [Test]
    public void Validate_InValidRequestIncorrectPersonalid_ArgumentExceptionThrown()
    {
       
        var validator = new RegisterAccountValidator(_userRepository);
        var request = new RegisterAccountRequest
        {
            Amount = 100,
            PersonalId = "12345678901"
        };

      
        Assert.Throws<ArgumentException>(() => validator.Validate(request), "Incorrect personal Id");
    }
    [Test]
    public void Validate_NullRequest_ArgumentNullExceptionThrown()
    {
        
        var validator = new RegisterAccountValidator(_userRepository);

        
        Assert.Throws<ArgumentNullException>(() => validator.Validate(null));
    }
    [Test]
    public void Validate_InvalidPersonalId_ArgumentExceptionThrown()
    {
        
        var validator = new RegisterAccountValidator(_userRepository);
        var request = new RegisterAccountRequest
        {
            Amount = 100,
            PersonalId = "abcd"
        };
        
        Assert.Throws<ArgumentException>(() => validator.Validate(request), "Irrelevant personal id");
    }
    [Test]
    public void Validate_NegativeAmount_ArgumentExceptionThrown()
    {
      
        var validator = new RegisterAccountValidator(_userRepository);
        var request = new RegisterAccountRequest
        {
            Amount = -100,
            PersonalId = "1234567891"
        };
        
        Assert.Throws<ArgumentException>(() => validator.Validate(request), "Amount must at least 0");
    }
    [Test]
    public void Validate_PersonalIdWithNonNumericCharacters_ArgumentExceptionThrown()
    {
   
        var validator = new RegisterAccountValidator(_userRepository);
        var request = new RegisterAccountRequest
        {
            Amount = 100,
            PersonalId = "1a2b3c4d5e"
        };
        Assert.Throws<ArgumentException>(() => validator.Validate(request), "Irrelevant personal id");
    }
    [Test]
    public void Validate_PersonalIdWithLengthLessThan10_ArgumentExceptionThrown()
    {
        
        var validator = new RegisterAccountValidator(_userRepository);
        var request = new RegisterAccountRequest
        {
            Amount = 100,
            PersonalId = "123456789"
        };

        Assert.Throws<ArgumentException>(() => validator.Validate(request), "Personal number must contain 11 digits");
    }
}